using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Abstract;
using GarajYeriHI.Repository.Shared.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Repository.Concrete
{
    public class VehicleRepository: Repository<Vehicle>,IVehicleRepository
    {
      

        public VehicleRepository(ApplicationDbContext context):base(context)
        {
          
        }

        public void DeleteVehiclesByUserId(int userId)
        {
            base.GetAll().Where(x => x.AppUserId == userId).ForEachAsync(x =>
            {
                x.IsDeleted = true;
            });
            base.Save();
        }

        public IEnumerable<Vehicle> GetAll(bool isAdmin,int userId)
        {

            if (isAdmin)
            {
                var result = base.GetAll().Select(v => new Vehicle
                {
                    Name = v.Name,
                    Odometer = v.Odometer,
                    Id = v.Id,
                    LicensePlate = v.LicensePlate,
                    VehicleType = v.VehicleType,
                    AppUser = v.AppUser
                });
                return result;
            }
            else
            {
              
                return base.GetAll(v=>v.AppUserId == userId).Select(v => new Vehicle
                {
                    Name = v.Name,
                    Odometer = v.Odometer,
                    Id = v.Id,
                    LicensePlate = v.LicensePlate,
                    VehicleType = v.VehicleType,
                    AppUser = v.AppUser
                   
                });
            }
        }

     

    
    }
}
