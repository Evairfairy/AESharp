using System;
using System.Net;
using System.Net.Sockets;

namespace AESharp.Interop
{
    public class InteropConnectionManager
    {
        private readonly IPEndPoint _masterRouterEndPoint;
        private TcpClient _client;

        public bool Connected => this._client.Connected;

        public InteropConnectionManager( IPEndPoint masterRouterEndPoint )
        {
            this._masterRouterEndPoint = masterRouterEndPoint;
            this._client = new TcpClient();
        }

        public InteropConnectionManager( IPAddress address, int port ) :
            this( new IPEndPoint( address, port ) )
        {
        }

        public InteropConnectionManager( string address, int port )
            : this( IPAddress.Parse( address ), port )
        {
        }

        public bool Connect( Action<TcpClient> callback = null, int attempts = 0 )
        {
            if ( this.Connected )
            {
                return this.Connected;
            }

            for ( int i = 0; ( i < attempts ) || ( attempts == 0 ); ++i )
            {
                this._client = new TcpClient();

                try
                {
                    this._client
                        .ConnectAsync( this._masterRouterEndPoint.Address, this._masterRouterEndPoint.Port )
                        .Wait();

                    if ( this.Connected )
                    {
                        callback?.Invoke( this._client );

                        return this.Connected;
                    }

                    throw new AggregateException();
                }
                catch ( AggregateException )
                {
                    this._client.Dispose();
                    Console.WriteLine( $"Failed to connect to the Master Router ({i + 1} attempts)" );
                }
                catch ( Exception ex )
                {
                    Console.WriteLine( $"{ex}" );
                }
            }

            return this.Connected;
        }
    }
}