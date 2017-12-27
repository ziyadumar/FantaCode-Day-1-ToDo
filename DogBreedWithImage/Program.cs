using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DogAPI.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DogBreedWithImage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
             Program.DoOp().GetAwaiter().GetResult();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        public static async Task DoOp() {
            var da = new DogRepository();
            var list = await da.GetBreedList();

        }
    
    
    }



    
}
