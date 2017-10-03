using System;
using System.Text;
using LiteDB;

namespace AESharp.Database
{
    internal enum LogLevel : byte
    {
        Cache = Logger.CACHE,
        Command = Logger.COMMAND,
        Disk = Logger.COMMAND,
        Error = Logger.ERROR,
        Full = Logger.FULL,
        Journal = Logger.JOURNAL,
        Lock = Logger.LOCK,
        None = Logger.NONE,
        Query = Logger.QUERY,
        Recovery = Logger.RECOVERY,
    }

    internal sealed class LiteDbConnectionStringBuilder
    {
        public string FileName { get; set; }
        public bool Journal { get; set; } = true;
        public string Password { get; set; }
        public int CacheSize { get; set; } = 5000;
        public TimeSpan TimeOut { get; set; }
        public FileMode Mode { get; set; } = FileMode.Exclusive;
        public long? InitialSize { get; set; } = null;
        public long? LimitSize { get; set; } = null;
        public bool Upgrade { get; set; }
        public LogLevel Log { get; set; } = LogLevel.None;
        public bool Async { get; set; } = false;

        /// <inheritdoc />
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendFormat( "Filename={0};", this.FileName ?? "" );
            builder.AppendFormat( "Journal={0};", this.Journal ? "true" : "false" );

            if( this.Password != null )
                builder.AppendFormat( "Password={0};", this.Password );

            builder.AppendFormat( "Cache Size={0};", this.CacheSize );
            builder.AppendFormat( "Timeout={0};", this.TimeOut );
            builder.AppendFormat( "Mode={0};", this.Mode );
            builder.AppendFormat( "Initial Size={0};", this.InitialSize );
            builder.AppendFormat( "Limit Size={0};", this.LimitSize );
            builder.AppendFormat( "Upgrade={0};", this.Upgrade ? "true" : "false" );
            builder.AppendFormat( "Log={0};", (byte)this.Log );
            builder.AppendFormat( "Async={0};", this.Async ? "true" : "false" );

            return builder.ToString();
        }
    }
}
