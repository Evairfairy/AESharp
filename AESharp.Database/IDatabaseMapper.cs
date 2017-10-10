using AutoMapper;

namespace AESharp.Database
{
    internal interface IDatabaseMapper<in T>
        where T : Entities.Database
    {
        void CreateMapping( IMapperConfigurationExpression config );
        void MigrateTo( T db );
    }
}
