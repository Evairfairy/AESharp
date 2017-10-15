using System;
using AESharp.Database.Configuration;
using LiteDB;

namespace AESharp.Database.Entities.LiteDb
{
    internal abstract class Database : IDisposable
    {
        private IDiskService DiskService { get; }
        protected BsonMapper Mapper => this.LiteDatabase.Mapper;
        public LiteDatabase LiteDatabase { get; }

        protected Database( DatabaseSettings settings, BsonMapper mapper = null )
            : this( new FileDiskService( settings.FileName ), settings.Password, mapper ) { }

        protected Database( IDiskService service, string password = null, BsonMapper mapper = null )
        {
            if( mapper == null )
            {
                mapper = new BsonMapper { SerializeNullValues = true };
                mapper.UseCamelCase();
            }

            this.DiskService = service;
            this.LiteDatabase = new LiteDatabase( this.DiskService, mapper, password );

            // ReSharper disable once VirtualMemberCallInConstructor
            this.Initialize();
        }

        /// <inheritdoc />
        public void Dispose() => this.LiteDatabase.Dispose();

        public void Flush() => this.DiskService.Flush();

        protected abstract void Initialize();
    }
}
