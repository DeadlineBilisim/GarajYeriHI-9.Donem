using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Models
{
    public class Policy
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }//sigorta firması
        public DateTime Validity { get; set; }//geçerlilik tarihi

    }
}
