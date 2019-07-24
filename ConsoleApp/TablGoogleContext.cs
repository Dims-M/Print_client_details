using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class TablGoogleContext : DbContext
    {

        public TablGoogleContext()
          : base("DbConnection1") //"DbConnection" - это имя будущей строки подключения к базе данных
        { }

        /// <summary>
        /// Связь между обьектами Базы данных и класами в програме.
        /// Посредник между бд и классами, описывающими данные.
        /// </summary>
        public DbSet<TablGoogle> TablGoogles { get; set; }
    }
}
