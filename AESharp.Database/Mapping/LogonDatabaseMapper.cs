using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AESharp.Database.Entities;
using AESharp.Database.Entities.LiteDb;
using AESharp.Database.Entities.LiteDb.Models.Accounts;
using AESharp.Database.Entities.MySql;
using AESharp.Database.Entities.MySql.Models.Logon;
using AutoMapper;

namespace AESharp.Database.Mapping
{
    internal sealed class LogonDatabaseMapper : DatabaseMapper<LogonDatabase, AccountsDatabase>
    {
        /// <inheritdoc />
        public override void ConfigurMapping( IMapperConfigurationExpression config )
        {
            config.CreateMap<Accounts, Account>()
                  .ForMember( dest => dest.Username, obj => obj.MapFrom( src => src.Login ) )
                  .ForMember(
                      dest => dest.ExpansionLevel,
                      obj => obj.ResolveUsing(
                          src =>
                          {
                              switch( src.Flags )
                              {
                                  case AccountFlags.Classic: return ExpansionLevel.Classic;
                                  case AccountFlags.TheBurningCrusade: return ExpansionLevel.TheBurningCrusade;
                                  case AccountFlags.WrathOfTheLichKing:
                                  case AccountFlags.WrathAndBurningCrusade: return ExpansionLevel.WrathOfTheLichKing;
                                  default: throw new NotImplementedException();
                              }
                          } )
                  )
                  .ForMember( dest => dest.Persmissions, obj => obj.Ignore() )
                  .ForMember( dest => dest.ForceLanguage, obj => obj.MapFrom( src => src.Language ) )
                  .ForMember( dest => dest.CreatedAt, obj => obj.MapFrom( src => src.JoinDate ) )
                  .ForMember( dest => dest.BannedUntil, obj => obj.MapFrom( src => src.BanTime ) )
                  .ForMember( dest => dest.MutedUntil, obj => obj.MapFrom( src => src.MutedTime ) )
                  .ForMember(
                      dest => dest.LastKnownIp,
                      obj => obj.ResolveUsing( src => IPAddress.Parse( src.LastIPAddress ) )
                  );

            config.CreateMap<IpBans, IpBan>()
                  .ForMember( dest => dest.Ip, obj => obj.ResolveUsing( src => IPAddress.Parse( src.IPAddress ) ) )
                  .ForMember( dest => dest.BannedUntil, obj => obj.MapFrom( src => src.ExpiresAt ) )
                  .ForMember( dest => dest.Reason, obj => obj.MapFrom( src => src.BanReason ) );
        }
    }
}
