using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IRepository<VehicleType> _vehicleTypeRepo;

        public VehicleTypeController(IRepository<VehicleType> vehicleTypeRepo)
        {
            _vehicleTypeRepo = vehicleTypeRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            //   return Json(new { data = _context.VehicleTypes.Where(vt => !vt.IsDeleted) });
            return Json(new { data = _vehicleTypeRepo.GetAll() });
        }

        [HttpPost]
        public IActionResult Add(VehicleType vehicleType)
        {
            _vehicleTypeRepo.Add(vehicleType);
            _vehicleTypeRepo.Save();
            //_context.VehicleTypes.Add(vehicleType);
            //_context.SaveChanges();
            return Ok(vehicleType);
        }


        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            _vehicleTypeRepo.DeleteById(id);
            _vehicleTypeRepo.Save();

            //var vehicleType = _context.VehicleTypes.Find(id);
            //vehicleType.IsDeleted = true;
            //vehicleType.DateDeleted= DateTime.Now;
            //_context.VehicleTypes.Update(vehicleType);
            //_context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(VehicleType vehicleType) 
        {
            _vehicleTypeRepo.Update(vehicleType);
            _vehicleTypeRepo.Save();
            //_context.VehicleTypes.Update(vehicleType);
            //_context.SaveChanges();
            return Ok(vehicleType);
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_vehicleTypeRepo.GetById(id));
        }
    }
}
