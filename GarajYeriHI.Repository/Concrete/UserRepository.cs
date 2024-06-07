using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Abstract;
using GarajYeriHI.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Repository.Concrete
{
    public class UserRepository:Repository<AppUser>,IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IVehicleRepository _vehicleRepository;

        public UserRepository(ApplicationDbContext context, IVehicleRepository vehicleRepository) : base(context)
        {
            _context = context;
            _vehicleRepository = vehicleRepository;
        }

        public override IQueryable<AppUser> GetAll()
        {
           return base.GetAll().Select(x => new AppUser
           {
               FullName = x.FullName,
               Id = x.Id,
               UserName = x.UserName,
               IsAdmin = x.IsAdmin,
               Vehicles = x.Vehicles
           });
        }

        public override AppUser DeleteById(int id)
        {
         
            _vehicleRepository.DeleteVehiclesByUserId(id);
           return base.DeleteById(id);





        }


    }
}
