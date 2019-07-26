using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WindowsFormsAppTestAppEnityCore.Model;

namespace WindowsFormsAppTestAppEnityCore
{
    class Vs2015WinFormsEfcSqliteCodeFirst20170304ExampleContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Vs2015WinFormsEfcSqliteCodeFirst20170304Example.sqlite");
        }
    }
}
