using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace mijnZorgRooster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

			//var rooster = new RoosterService(new DateTime(2019,02,14));
			//var dagen = rooster.getAantalDagen();
			//System.Diagnostics.Debug.WriteLine("Er is een nieuw rooster aangemaakt met aantal dagen: " + rooster.getAantalDagen());
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
