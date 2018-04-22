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
            string seeder = "";
            bool seed = false;
            
            for(int i = 0; i < arguments.Count; i++) {
                if(arguments[i] == "seed") {
                    if(i < arguments.Count - 1 && arguments[i + 1].StartsWith("--")) {
                        seeder = arguments[i + 1].Substring(2);
                        arguments.RemoveAt(i + 1);
                    } 
                    seed = true;
                    arguments.RemoveAt(i);
                }
            }

            BuildWebHost(arguments.ToArray())
                        .SeedDatabase(seed, seeder)
                        .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
