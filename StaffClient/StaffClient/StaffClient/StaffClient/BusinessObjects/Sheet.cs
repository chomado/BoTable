using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffClient.BusinessObjects
{
    /*
{
  "id": "8",
  "status": "0",
  "smoke": "no",
  "type": "counter",
  "capacity": "1"
}
    */
    public class Sheet
    {
        public int Id { get; set; }
        public SheetStatus Status { get; set; }
        public string Smoke { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public string Text => $"座席番号 {this.Id} {this.Capacity} 人掛け {(this.Type == "counter" ? "カウンター" : "テーブル")} 席";

        public string Detail => $"{(this.Smoke == "no" ? "禁煙" : "喫煙")} {(this.Status == 0 ? "空" : "")}";
    }

    public enum SheetStatus : int
    {
        Empty = 0,
        Fill = 1,
    }
}
