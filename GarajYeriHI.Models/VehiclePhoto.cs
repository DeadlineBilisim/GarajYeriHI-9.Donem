using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Models
{
    public class VehiclePhoto:BaseModel
    {
        public string Path {  get; set; }//dosya yolu/yada dosya adı 
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
