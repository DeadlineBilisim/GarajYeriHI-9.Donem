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
    
        private readonly IRepository<PolicyType> _policyTypeRepository;

        public PolicyTypeController(IRepository<PolicyType> policyTypeRepository)
        {
            _policyTypeRepository = policyTypeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Json(new {data=_policyTypeRepository.GetAll()});
        }

        [HttpPost]
        public IActionResult Add(PolicyType policyType)
        {
           return Ok(_policyTypeRepository.Add(policyType));
        }
      
        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
          var result= _policyTypeRepository.DeleteById(id);
            if (result != null)
            {
               return Ok(result);
            }
            else
            {
                return BadRequest("HATA - Nesne bulunamadı");
            }
          
        }

        [HttpPost]
        public IActionResult Update(PolicyType policyType) {

            return Ok(_policyTypeRepository.Update(policyType));
        }

        [HttpPost]
        public IActionResult GetById(int id) 
        {
            return Ok(_policyTypeRepository.GetById(id));
        }
        


    }
}
