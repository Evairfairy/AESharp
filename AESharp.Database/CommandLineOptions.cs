using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace AESharp.Database
{
    [Verb(
        "migrate",
        Hidden = false,
        HelpText = "Start the application in migration mode to migrate data from MySQL to LiteDB" )]
    internal sealed class MigrateOptions { }

    internal sealed class CommandLineOptions
    {
    }
}
