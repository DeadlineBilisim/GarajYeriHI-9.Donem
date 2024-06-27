using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GarajYeriHI.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
      
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult Index()
        {
          
          
            return View();
        }

        public IActionResult GetAll()
        {
            bool isAdmin = User.IsInRole("Admin");
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

          return Json(new { data = _vehicleRepository.GetAll(isAdmin,userId)  });

        }

        [HttpPost]
        public IActionResult Add(Vehicle vehicle)
        {
            return Ok(_vehicleRepository.Add(vehicle));

        }
        [HttpPost]
        public IActionResult Update(Vehicle vehicle)
        {
            return Ok(_vehicleRepository.Update(vehicle));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
         _vehicleRepository.DeleteById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_vehicleRepository.GetById(id));
        }



    }
}
