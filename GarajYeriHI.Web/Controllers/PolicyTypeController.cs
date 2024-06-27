using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PolicyTypeController : Controller
    {

        private readonly IPolicyTypeService _policyTypeService;

        public PolicyTypeController(IPolicyTypeService policyTypeService)
        {
            _policyTypeService = policyTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Json(new {data=_policyTypeService.GetAllPolicyType()});
        }

        [HttpPost]
        public IActionResult Add(PolicyType policyType)
        {
           return Ok(_policyTypeService.Add(policyType));
        }
      
        [HttpPost]
        public async Task<IActionResult> SoftDelete(int id)
        {
         
            return Ok(_policyTypeService.Delete(id));
          
        }

        [HttpPost]
        public IActionResult Update(PolicyType policyType) {

            return Ok(_policyTypeService.Update(policyType));
        }

        [HttpPost]
        public IActionResult GetById(int id) 
        {
            return Ok(_policyTypeService.GetById(id));
        }
        


    }
}
