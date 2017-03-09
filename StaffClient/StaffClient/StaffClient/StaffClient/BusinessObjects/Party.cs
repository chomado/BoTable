using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffClient.BusinessObjects
{
    /*
        {
          "id": "0",
          "smoke": "no",
          "type": "table",
          "capacity": "4"
        }
    */
    public class Party
    {
        public int Id { get; set; }
        public string Smoke { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
    }
}
