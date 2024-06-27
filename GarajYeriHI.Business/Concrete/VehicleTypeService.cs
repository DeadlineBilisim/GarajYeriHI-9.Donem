using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Business.Concrete
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public VehicleTypeService(IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public VehicleType Add(VehicleType vehicleType)
        {
           return _vehicleTypeRepository.Add(vehicleType);
        }

        public bool Delete(int vehicleTypeId)
        {
          _vehicleTypeRepository.DeleteById(vehicleTypeId);
            return true;
        }

        public IQueryable<VehicleType> GetAll()
        {
           return _vehicleTypeRepository.GetAll();
        }

        public VehicleType GetById(int vehicleTypeId)
        {
            return _vehicleTypeRepository.GetById(vehicleTypeId);
        }

        public VehicleType Update(VehicleType vehicleType)
        {
           return _vehicleTypeRepository.Update(vehicleType);
        }
    }
}
