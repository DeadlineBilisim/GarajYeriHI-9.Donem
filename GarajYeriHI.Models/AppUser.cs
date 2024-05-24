using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Models
{
    public class AppUser:BaseModel
    {
        public string FullName {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
