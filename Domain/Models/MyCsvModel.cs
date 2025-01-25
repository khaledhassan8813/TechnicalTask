using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MyCsvModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryCode { get; set; }
        public long Number { get; set; }
        public string FullAddress { get; set; }
    }
}
