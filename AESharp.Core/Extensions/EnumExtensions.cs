using System;

namespace AESharp.Core.Extensions
{
    public static class EnumExtensions
    {
    }

    public static class EnumHelpers
    {
        public static void ThrowIfUndefined(Type t, object o)
        {
            if (!Enum.IsDefined(t, o))
                throw new InvalidOperationException();
        }
    }
}