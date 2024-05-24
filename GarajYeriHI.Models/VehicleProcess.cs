using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Models
{
    public class VehicleProcess:BaseModel
    {
        public double Odometer {  get; set; }
        public double? Price {  get; set; }
    }
}
