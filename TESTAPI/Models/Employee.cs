using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public Nullable<int> Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
    }
}
