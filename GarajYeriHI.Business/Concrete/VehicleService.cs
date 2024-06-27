using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Business.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;

        public VehicleService(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle Add(Vehicle vehicle)
        {
           return _vehicleRepository.Add(vehicle);
        }

        public bool Delete(int vehicleId)
        {
           _vehicleRepository.DeleteById(vehicleId);
            return true;
        }

        public bool DeleteVehiclesByUserId(int userId)
        {
            _vehicleRepository.GetAll().Where(x => x.AppUserId == userId).ForEachAsync(x =>
            {
                x.IsDeleted = true;
            });
          _vehicleRepository.Save();
            return true;
        }

        public IQueryable<Vehicle> GetAll(bool isAdmin, int userId)
        {

            if (isAdmin)
            {
                var result = _vehicleRepository.GetAll().Select(v => new Vehicle
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

                return _vehicleRepository.GetAll(v => v.AppUserId == userId).Select(v => new Vehicle
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

   

        public Vehicle GetByGuid(Guid guid)
        {
           return _vehicleRepository.GetByGuid(guid);
        }

        public Vehicle GetById(int vehicleId)
        {
          return _vehicleRepository.GetById(vehicleId);
        }

        public Vehicle Update(Vehicle vehicle)
        {
          return _vehicleRepository.Update(vehicle);
        }
    }
}
