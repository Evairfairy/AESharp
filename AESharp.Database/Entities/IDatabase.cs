using LiteDB;

namespace AESharp.Database.Entities
{
    internal interface IDatabase
    {
        LiteDatabase Database { get; }

        void Flush();
    }
}
