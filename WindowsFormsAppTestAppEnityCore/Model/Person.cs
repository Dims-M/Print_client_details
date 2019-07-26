using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppTestAppEnityCore.Model
{
  public  class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? CityId { get; set; }

        [InverseProperty("People")]
        public virtual City City { get; set; }
    }
}
