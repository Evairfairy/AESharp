using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Core.Extensions;
using AESharp.Networking.Exceptions;
using AESharp.Networking.Extensions;
using AESharp.Networking.Interfaces.ClientManagement;

namespace AESharp.Networking.Data
{
    /// <summary>
    ///     Implements most functionality needed for a remote client, but must be inherited to handle packets
    /// </summary>
    public abstract class RemoteClient : IRemoteClient
    {
        private const int BufferSize = 4096;

        protected RemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
        {
            this.RawClient = rawClient;
            this.TokenSource = tokenSource;
            this.CancellationToken = this.TokenSource.Token;
        }

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
                    await this.HandleDataTask( buffer, token );
                }
                catch ( InvalidPacketException ex )
                {
                    Console.WriteLine( ex.Message );
                    this.DisconnectEx( 100 ).RunAsync();
                }
            }
        }

        public async Task SendDataTask( byte[] data, CancellationToken token )
        {
            await this.RawClient.GetStream().WriteAsync( data, 0, data.Length, token );
        }

        /// <summary>
        ///     Handles data sent by the client
        /// </summary>
        /// <param name="data">Data that was sent by the client</param>
        /// <param name="token">cancellation token</param>
        /// <returns>Task</returns>
        public abstract Task HandleDataTask( byte[] data, CancellationToken token );

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
            catch ( ObjectDisposedException )
            {
            }
        }

        /// <summary>
        ///     Sends the byte[] specified to the client
        /// </summary>
        /// <param name="data">data to send to the client</param>
        /// <returns>Task</returns>
        public async Task SendDataTask( byte[] data )
        {
            await this.SendDataTask( data, this.CancellationToken );
        }

        /// <summary>
        ///     Handles data sent by the client
        /// </summary>
        /// <param name="data">Data that was sent by the client</param>
        /// <returns>Task</returns>
        public async Task HandleDataTask( byte[] data )
        {
            await this.HandleDataTask( data, this.CancellationToken );
        }

        ~RemoteClient()
        {
            // Disconnect sockets before destroying object
            this.Disconnect( TimeSpan.FromMilliseconds( 100 ) ).RunAsync();
        }
    }
}