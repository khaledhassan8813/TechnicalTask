using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PersonDetail
    {
        public int Id { get; set; } // Primary key
        public string name { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        [Column("telephone Number")]
        public string telephoneNumber { get; set; }
    }
}
