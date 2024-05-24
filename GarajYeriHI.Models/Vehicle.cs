using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Models
{
    public class Vehicle:BaseModel
    {
        public string LicensePlate { get; set; }//plaka
        public string Name { get; set; }
        public double Odometer {  get; set; }
    }
}
