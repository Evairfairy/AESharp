﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace AESharp.Networking.Middleware
{
    public class MiddlewareHandler<TMetaPacket, TContext> where TMetaPacket : MetaPacket
    {
        private readonly List<IMiddleware<TMetaPacket, TContext>> _middleware =
            new List<IMiddleware<TMetaPacket, TContext>>();

        public void RegisterMiddleware(IMiddleware<TMetaPacket, TContext> middleware)
        {
            _middleware.Add(middleware);
        }

        public async Task<TMetaPacket> RunMiddlewareAsync(TMetaPacket packet, TContext context)
        {
            foreach (var middleware in _middleware)
            {
                packet = await middleware.CallMiddlewareAsync(packet, context);

                if (packet.Handled)
                    break;
            }

            return packet;
        }
    }
}