using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportCVS.Models
{
    public class CSVModel
    {
        public int Id { get; set; }
        public string csvId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
