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
    public class PolicyService : IPolicyService
    {
        private readonly IRepository<Policy> _repository;
        private readonly IRepository<Vehicle> _vehicleRepository;

        public PolicyService(IRepository<Policy> repository, IRepository<Vehicle> vehicleRepository)
        {
            _repository = repository;
            _vehicleRepository = vehicleRepository;
        }

        public Policy Add(Policy policy)
        {
           return _repository.Add(policy);
        }

        public bool Delete(int policyId)
        {
           _repository.DeleteById(policyId);
            return true;
        }

        public IQueryable<Policy> GetAllByUser(AppUser user)
        {
       //  List<Vehicle> vehicles=   _vehicleRepository.GetAll(v=>v.AppUserId==user.Id).ToList();

        //  return  _repository.GetAll(p=>vehicles.Contains(p.Vehicle));

            //List<int> vehicleIds = _vehicleRepository.GetAll(v => v.AppUserId == user.Id).Select(v => v.Id).ToList();
            //return _repository.GetAll(p => vehicleIds.Contains(p.VehicleId));



            return _repository.GetAll().Include(p=>p.Vehicle).Where(p => p.Vehicle.AppUserId == user.Id);
            // return  _repository.GetAll(p=>p.Vehicle.AppUserId==user.Id);

        }

        public IQueryable<Policy> GetAllByVehicleGuid(Guid vehicleGuid)
        {
          int vehicleId= _vehicleRepository.GetByGuid(vehicleGuid).Id;

            return _repository.GetAll(p=>p.VehicleId==vehicleId);




        }

        public Policy GetById(int policyId)
        {
            return _repository.GetById(policyId);
        }

        public Policy Update(Policy policy)
        {
            return _repository.Update(policy);
        }
    }
}
