namespace AESharp.Database.Migrations
{
    internal abstract class Migration<T>
    {
        public long Id { get; }
        public string Description { get; protected set; }
        public T Database { get; }

        protected Migration( T db, long id, string description = null )
        {
            this.Database = db;
            this.Id = id;
            this.Description = description;
        }    

        public abstract void Upgrade();
        public abstract void Downgrade();
    }
}
