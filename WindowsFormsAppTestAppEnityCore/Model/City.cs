using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WindowsFormsAppTestAppEnityCore.Model
{
  public  class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Person> People { get; set; }
    }



}
