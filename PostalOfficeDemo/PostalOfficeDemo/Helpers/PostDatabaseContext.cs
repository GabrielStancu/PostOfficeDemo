using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PostalOfficeDemo.Helpers
{
    public class PostDatabaseContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        private const string databaseName = "database.db";

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = string.Empty;

            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported.");
            }

            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
