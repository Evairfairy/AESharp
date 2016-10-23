using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Core.Extensions;
using AESharp.Networking.Exceptions;
using AESharp.Networking.Extensions;

namespace AESharp.Networking.Data
{
    /// <summary>
    ///     Implements most functionality needed for a remote client, but must be inherited to handle packets
    /// </summary>
    public abstract class RemoteClient
    {
        private const int BufferSize = 4096;

        public TcpClient RawClient { get; }

        public CancellationToken CancellationToken { get; }
        private CancellationTokenSource TokenSource { get; }

        /// <summary>
        ///     GUID automatically constructed by calling Guid.NewGuid().
        /// </summary>
        public Guid ClientGuid { get; } = Guid.NewGuid();

        /// <summary>
        ///     True if the underlying TcpClient is connected - if false the RemoteClient is invalid and should no longer be used.
        /// </summary>
        public bool Connected => this.RawClient.Connected;

        protected RemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
        {
            this.RawClient = rawClient;
            this.TokenSource = tokenSource;
            this.CancellationToken = this.TokenSource.Token;
        }

        /// <summary>
        ///     Begins listening for data, calling this.HandleDataAsync when data is received
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task ListenForDataTask( CancellationToken token )
        {
            if ( this.RawClient == null )
            {
                throw new NullReferenceException( $"{nameof( this.RawClient )} cannot be null" );
            }

            if ( !this.Connected )
            {
                throw new InvalidOperationException( "Must be connected to listen for data" );
            }

            NetworkStream ns = this.RawClient.GetStream();

            while ( !token.IsCancellationRequested && this.Connected )
            {
                byte[] buffer = new byte[BufferSize];
                int bytesRead = await ns.ReadAsync( buffer, 0, buffer.Length, token );

                if ( bytesRead == 0 )
                {
                    this.DisconnectEx( 100 ).RunAsync();
                    break;
                }

                Array.Resize( ref buffer, bytesRead );

                try
                {
                    await this.HandleDataAsync( buffer, token );
                }
                catch ( InvalidPacketException ex )
                {
                    Console.WriteLine( ex.Message );
                    this.DisconnectEx( 100 ).RunAsync();
                }
            }
        }

        /// <summary>
        ///     Sends a packet to the RemoteClient
        /// </summary>
        /// <param name="packet">Packet to send</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task SendPacketAsync( Packet packet, CancellationToken token )
        {
            byte[] buffer = packet.BuildPacket();
            await this.RawClient.GetStream().WriteAsync( buffer, 0, buffer.Length, token );
        }

        /// <summary>
        ///     Sends a packet to the RemoteClient
        /// </summary>
        /// <param name="packet">Packet to send</param>
        /// <returns>Task</returns>
        public async Task SendPacketAsync( Packet packet )
        {
            await this.SendPacketAsync( packet, this.CancellationToken );
        }

        /// <summary>
        ///     Handles data sent by the client
        /// </summary>
        /// <param name="data">Data that was sent by the client</param>
        /// <param name="token">cancellation token</param>
        /// <returns>Task</returns>
        public abstract Task HandleDataAsync( byte[] data, CancellationToken token );

        /// <summary>
        ///     Closes both receive and send sockets for the underlying TcpClient. After calling this method, the RemoteClient
        ///     becomes invalid.
        /// </summary>
        public async Task Disconnect( TimeSpan timeToAllowForCancellation )
        {
            this.TokenSource.Cancel();
            await Task.Delay( timeToAllowForCancellation, CancellationToken.None );

            try
            {
                this.RawClient?.Client?.Shutdown( SocketShutdown.Both );
            }
            // Socket has already been closed
            catch ( ObjectDisposedException ) { }
        }

        /// <summary>
        ///     Handles data sent by the client
        /// </summary>
        /// <param name="data">Data that was sent by the client</param>
        /// <returns>Task</returns>
        public async Task HandleDataTask( byte[] data )
        {
            await this.HandleDataAsync( data, this.CancellationToken );
        }

        ~RemoteClient()
        {
            // Disconnect sockets before destroying object
            this.Disconnect( TimeSpan.FromMilliseconds( 100 ) ).RunAsync();
        }
    }
}