using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Models
{
    public class VehicleInspection:BaseModel
    {
        public string? Description {  get; set; }
        public double Odometer { get; set; }
        public DateTime Validity { get; set; }
        public string? FilePath { get; set; }//rapor dosyası tutulacak
        public bool IsPassed { get; set; } = true;
    }
}
