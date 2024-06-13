using GarajYeriHI.Models;
using GarajYeriHI.Repository.Abstract;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    public class VehiclePhotoController : Controller
    {
       
        private readonly IVehiclePhotoRepository _vehiclePhotoRepo;

        public VehiclePhotoController(IVehiclePhotoRepository vehiclePhotoRepo)
        {
            _vehiclePhotoRepo = vehiclePhotoRepo;
        }

        public IActionResult Index(Guid id)
        {
         
            return View(_vehiclePhotoRepo.GetAll(id));
        }

        //[HttpPost]
        //public IActionResult Add(List<VehiclePhoto> vehiclePhotos) {
        


        
        //}



    }
}
