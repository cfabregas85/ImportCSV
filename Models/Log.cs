using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportCVS.Models
{
    public class Log
    {
        public int logId { get; set; }
        public string message { get; set; }
        public DateTime Date { get; set; }

        public Log()
        {
            this.Date = DateTime.Now;
        }
    }
}
