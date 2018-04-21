using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using FKTeplice.Extensions;

namespace FKTeplice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arguments = args.ToList();
            bool seed = arguments.RemoveAll(x => x == "seed") > 0;
            
            BuildWebHost(arguments.ToArray())
                        .SeedDatabase(seed)
                        .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
