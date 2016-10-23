using System;
using System.Collections.Generic;

namespace AESharp.Networking.Data
{
    public class RemoteClientRepository
    {
        /// <summary>
        ///     Holds the IRemoteClient objects. All access to this Dictionary is made thread-safe.
        /// </summary>
        private readonly Dictionary<Guid, RemoteClient> _remoteClients = new Dictionary<Guid, RemoteClient>();

        /// <summary>
        ///     Thread-safe access method to add a client to the repository.
        /// </summary>
        /// <param name="client">Client to add</param>
        /// <returns>The GUID used to identify the client to the repository</returns>
        public Guid AddClient( RemoteClient client )
        {
            if( client == null )
                throw new NullReferenceException( $"Parameter {nameof( client )} cannot be null" );

            lock( this._remoteClients )
                this._remoteClients.Add( client.ClientGuid, client );
            return client.ClientGuid;
        }

        /// <summary>
        ///     Thread-safe access method to remove a client from the repository.
        /// </summary>
        /// <param name="clientGuid">The GUID used to identify the client</param>
        public void RemoveClient( Guid clientGuid )
        {
            if( clientGuid == Guid.Empty )
                throw new NullReferenceException( $"Parameter {nameof( clientGuid )} cannot be empty" );

            lock( this._remoteClients )
            {
                if( this._remoteClients.ContainsKey( clientGuid ) )
                    this._remoteClients.Remove( clientGuid );
            }
        }

        public void RemoveAllClients()
        {
            lock( this._remoteClients )
                this._remoteClients.Clear();
        }

        /// <summary>
        ///     Returns the IRemoteClient identified by clientGuid
        /// </summary>
        /// <param name="clientGuid">The GUID used to identify the client</param>
        /// <returns>The IRemoteClient identified by clientGuid</returns>
        public RemoteClient GetClient( Guid clientGuid )
        {
            if( clientGuid == Guid.Empty )
                throw new NullReferenceException( $"Parameter {nameof( clientGuid )} cannot be empty" );

            lock( this._remoteClients )
                return this._remoteClients[clientGuid];
        }

        /// <summary>
        ///     Returns all clients in the repository.
        /// </summary>
        /// <returns>An IEnumerable of all clients in the repository</returns>
        public IEnumerable<RemoteClient> GetAllClients()
        {
            RemoteClient[] clients = new RemoteClient[this._remoteClients.Count];

            lock( this._remoteClients )
                this._remoteClients.Values.CopyTo( clients, 0 );

            return clients;
        }
    }
}
