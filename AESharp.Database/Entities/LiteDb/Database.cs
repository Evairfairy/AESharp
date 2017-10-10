using System;
using AESharp.Database.Configuration;
using LiteDB;

namespace AESharp.Database.Entities
{
    internal abstract class Database : IDisposable
    {
        private IDiskService DiskService { get; }
        protected BsonMapper Mapper => this.LiteDatabase.Mapper;
        public LiteDatabase LiteDatabase { get; }

        protected Database( DatabaseSettings settings, BsonMapper mapper = null )
        {
            if( mapper == null )
            {
                mapper = new BsonMapper { SerializeNullValues = true };
                mapper.UseCamelCase();
            }
            
            this.DiskService = new FileDiskService( settings.FileName );
            this.LiteDatabase = new LiteDatabase( this.DiskService, mapper, settings.Password );
        }

        /// <inheritdoc />
        public void Dispose() => this.LiteDatabase.Dispose();

        public void Flush() => this.DiskService.Flush();
    }
}
