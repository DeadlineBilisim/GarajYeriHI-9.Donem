using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Abstract;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    public class VehiclePhotoController : Controller
    {
       
     private readonly IVehiclePhotoService _vehiclePhotoService;

        public VehiclePhotoController(IVehiclePhotoService vehiclePhotoService)
        {
            _vehiclePhotoService = vehiclePhotoService;
        }

        public IActionResult Index(Guid id)
        {
         
            return View(_vehiclePhotoService.GetAll(id));
        }

        //[HttpPost]
        //public IActionResult Add(List<VehiclePhoto> vehiclePhotos) {




        //}

        [HttpPost]
        public IActionResult Delete(VehiclePhoto vehiclePhoto)
        {
           return Ok( _vehiclePhotoService.Delete(vehiclePhoto.Id));
            
        }

        [HttpPost]
        public IActionResult Update(VehiclePhoto vehiclePhoto)
        {
            return Ok(_vehiclePhotoService.Update(vehiclePhoto));
        }
       

    }
}
