using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class VehicleProcessTypeController : Controller
    {
      private readonly IRepository<VehicleProcessType> _repository;

        public VehicleProcessTypeController(IRepository<VehicleProcessType> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data=_repository.GetAll() });
        }

        [HttpPost]
        public IActionResult Add(VehicleProcessType vehicleProcessType)
        {
           
            return Ok(_repository.Add(vehicleProcessType));
        }
        [HttpPost]
        public IActionResult Update(VehicleProcessType vehicleProcessType)
        {
           
            return Ok(_repository.Update(vehicleProcessType));
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
          _repository.DeleteById(id);
            return Ok();
        }

      

        [HttpPost]
        public IActionResult GetById(int id)
        {

            return Ok(_repository.GetById(id));

        }
    }
}
