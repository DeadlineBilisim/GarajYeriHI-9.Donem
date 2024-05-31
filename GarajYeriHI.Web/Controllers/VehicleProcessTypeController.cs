using GarajYeriHI.Data;
using GarajYeriHI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class VehicleProcessTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleProcessTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data=_context.VehicleProcessTypes.Where(vpt=>!vpt.IsDeleted).ToList() });
        }

        [HttpPost]
        public IActionResult Add(VehicleProcessType vehicleProcessType)
        {
            _context.VehicleProcessTypes.Add(vehicleProcessType);
            _context.SaveChanges();
            return Ok(vehicleProcessType);
        }
        [HttpPost]
        public IActionResult Update(VehicleProcessType vehicleProcessType)
        {
            _context.VehicleProcessTypes.Update(vehicleProcessType);
            _context.SaveChanges();
            return Ok(vehicleProcessType);
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var vehicleProcessType = _context.VehicleProcessTypes.Find(id);
            vehicleProcessType.IsDeleted = true;
            vehicleProcessType.DateDeleted = DateTime.Now;
            _context.VehicleProcessTypes.Update(vehicleProcessType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult HardDelete(VehicleProcessType vehicleProcessType) 
        {
            _context.VehicleProcessTypes.Remove(vehicleProcessType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {

            return Ok(_context.VehicleProcessTypes.Find(id));

        }
    }
}
