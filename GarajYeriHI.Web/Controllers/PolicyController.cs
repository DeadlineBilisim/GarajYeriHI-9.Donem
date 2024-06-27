using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    public class PolicyController : Controller
    {
      private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllByVehicleGuid(Guid vehicleGuid)
        {
            return Json(_policyService.GetAllByVehicleGuid(vehicleGuid));
        }

        [HttpPost]
        public IActionResult GetAllByUser(AppUser user) {

            return Json(_policyService.GetAllByUser(user));
        }
        [HttpPost]
        public IActionResult Add(Policy policy)
        {
            return Ok(_policyService.Add(policy));
        }
        [HttpPost]
        public IActionResult Update(Policy policy) { 
            return Ok(_policyService.Update(policy));
        }
        [HttpPost]
        public IActionResult Delete(int policyId) {
        
            return Ok(_policyService.Delete(policyId));
        }
    }
}
