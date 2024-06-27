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
    public class UserService : IUserService
    {
        private readonly IRepository<AppUser> _userRepository;

        public UserService(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public AppUser Add(AppUser user)
        {
            return _userRepository.Add(user);
        }

        public AppUser CheckLogin(string username, string password)
        {
            return _userRepository.GetFirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public bool Delete(int userId)
        {
           _userRepository.DeleteById(userId);
            return true;
        }

        public IQueryable<AppUser> GetAll()
        {
            return _userRepository.GetAll().Select(x => new AppUser
            {
                FullName = x.FullName,
                Id = x.Id,
                UserName = x.UserName,
                IsAdmin = x.IsAdmin,
                Vehicles = x.Vehicles
            });
        }

        public AppUser GetById(int userId)
        {
           return _userRepository.GetById(userId);
        }

        public AppUser Update(AppUser user)
        {
           return _userRepository.Update(user);
        }
    }
}
