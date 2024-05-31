using GarajYeriHI.Data;
using GarajYeriHI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = _context.VehicleTypes.Where(vt => !vt.IsDeleted) });
        }

        [HttpPost]
        public IActionResult Add(VehicleType vehicleType)
        {
            _context.VehicleTypes.Add(vehicleType);
            _context.SaveChanges();
            return Ok(vehicleType);
        }

        [HttpPost]
        public IActionResult HardDelete(VehicleType vehicleType)
        {
            _context.VehicleTypes.Remove(vehicleType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var vehicleType = _context.VehicleTypes.Find(id);
            vehicleType.IsDeleted = true;
            _context.VehicleTypes.Update(vehicleType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(VehicleType vehicleType) 
        {
            _context.VehicleTypes.Update(vehicleType);
            _context.SaveChanges();
            return Ok(vehicleType);
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_context.VehicleTypes.Find(id));
        }
    }
}
