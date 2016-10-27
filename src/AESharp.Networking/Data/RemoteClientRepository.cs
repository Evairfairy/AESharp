using System;
using System.Collections.Generic;
using AESharp.Networking.Middleware;

namespace AESharp.Networking.Data
{
    public class RemoteClientRepository<TMetaPacket, T> where T : RemoteClient<TMetaPacket>
                                                        where TMetaPacket : MetaPacket, new()
    {
        /// <summary>
        ///     Holds the RemoteClient objects. All access to this Dictionary is made thread-safe.
        /// </summary>
        private readonly Dictionary<Guid, T> _remoteClients = new Dictionary<Guid, T>();

        /// <summary>
        ///     Thread-safe access method to add a client to the repository.
        /// </summary>
        /// <param name="client">Client to add</param>
        /// <returns>The GUID used to identify the client to the repository</returns>
        public Guid AddClient( T client )
        {
            if ( client == null )
            {
                throw new NullReferenceException( $"Parameter {nameof( client )} cannot be null" );
            }

            lock ( this._remoteClients )
            {
                this._remoteClients.Add( client.ClientGuid, client );
            }
            return client.ClientGuid;
        }

        /// <summary>
        ///     Thread-safe access method to remove a client from the repository.
        /// </summary>
        /// <param name="clientGuid">The GUID used to identify the client</param>
        public void RemoveClient( Guid clientGuid )
        {
            if ( clientGuid == Guid.Empty )
            {
                throw new NullReferenceException( $"Parameter {nameof( clientGuid )} cannot be empty" );
            }

            lock ( this._remoteClients )
            {
                if ( this._remoteClients.ContainsKey( clientGuid ) )
                {
                    this._remoteClients.Remove( clientGuid );
                }
            }
        }

        public void RemoveAllClients()
        {
            lock ( this._remoteClients )
            {
                this._remoteClients.Clear();
            }
        }

        /// <summary>
        ///     Returns the RemoteClient identified by clientGuid
        /// </summary>
        /// <param name="clientGuid">The GUID used to identify the client</param>
        /// <returns>The RemoteClient identified by clientGuid</returns>
        public T GetClient( Guid clientGuid )
        {
            if ( clientGuid == Guid.Empty )
            {
                throw new NullReferenceException( $"Parameter {nameof( clientGuid )} cannot be empty" );
            }

            lock ( this._remoteClients )
            {
                return this._remoteClients[clientGuid];
            }
        }

        /// <summary>
        ///     Returns all clients in the repository.
        /// </summary>
        /// <returns>An IEnumerable of all clients in the repository</returns>
        public List<T> GetAllClients()
        {
            List<T> clients = new List<T>();

            lock ( this._remoteClients )
            {
                clients.AddRange( this._remoteClients.Values );
            }

            return clients;
        }
    }
}