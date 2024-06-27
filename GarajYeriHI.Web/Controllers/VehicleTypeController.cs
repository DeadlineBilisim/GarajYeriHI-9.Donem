using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
           return Json(new { data = _vehicleTypeService.GetAll() });
        }

        [HttpPost]
        public IActionResult Add(VehicleType vehicleType)
        {
           
            return Ok(_vehicleTypeService.Add(vehicleType));
        }


        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
          
        
            return Ok(_vehicleTypeService.Delete(id));
        }

        [HttpPost]
        public IActionResult Update(VehicleType vehicleType) 
        {
           
         
            return Ok(_vehicleTypeService.Update(vehicleType));
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_vehicleTypeService.GetById(id));
        }
    }
}
