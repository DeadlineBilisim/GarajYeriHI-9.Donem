﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Models
{
    public class VehiclePhoto:BaseModel
    {
       
        public string Description {  get; set; }
        public string Path {  get; set; }//dosya yolu/yada dosya adı 
       
        public int VehicleId { get; set; }
      //  public virtual Vehicle Vehicle { get; set; }
    }
}
