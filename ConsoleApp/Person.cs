using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SQLite;

namespace ConsoleApp
{
    class Personsss
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [MaxLength(50), NotNull]
        public string NameClient { get; set; }

        [MaxLength(50), NotNull]
        public string LastNameLogin { get; set; }

        [MaxLength(50), NotNull]
        public string LastNamePass { get; set; }

        [NotNull]
        public DateTime BirthDate { get; set; }

        [Ignore]
        public string FullName
        {
            get
            {
                return string.Format(
                    "{0} {1} {2}",
                    NameClient,
                    LastNameLogin,
                    LastNamePass
                );
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: {1} {2}",
                Id,
                FullName,
                BirthDate.ToString("dd-MM-yyyy")
            );
        }
    }
}
