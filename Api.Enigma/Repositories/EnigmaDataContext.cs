using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Enigma.Repositories
{
    public class EnigmaDataContext : DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
            string conn = configuration.GetConnectionString("EnigmaDB");
            options.UseSqlite(conn);
        }*/
    }
}
