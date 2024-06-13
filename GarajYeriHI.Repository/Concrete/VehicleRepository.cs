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
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
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
                var result = _context.Vehicles.Where(v => !v.IsDeleted).Select(v => new Vehicle
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
              
                return _context.Vehicles.Where(v => !v.IsDeleted && v.AppUserId == userId).Select(v => new Vehicle
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
