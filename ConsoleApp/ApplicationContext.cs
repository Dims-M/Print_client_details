using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations.Model;
//using SQLiteApp.Model;

namespace ConsoleApp
{
    /// <summary>
    /// Связь с БД
    /// </summary>
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }


        //Соединение с БД
        public DbSet<Phone> Phones { get; set; }
       // public DbSet<GoogleTabl> GoogleTabls { get; set; }

    }
}
