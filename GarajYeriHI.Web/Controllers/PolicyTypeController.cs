using GarajYeriHI.Data;
using GarajYeriHI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeriHI.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PolicyTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        //Bu metotları kullanan arayüzleri yapınız. Ve Layout'ta tanımlamalar menusunun sadece Admin kullanıcılarında görünmesini sağlayınız.


        public PolicyTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Json(new {data=_context.PolicyTypes.Where(pt=>!pt.IsDeleted)});
        }

        [HttpPost]
        public IActionResult Add(PolicyType policyType)
        {
            _context.PolicyTypes.Add(policyType);
            _context.SaveChanges();
            return Ok(policyType);
        }
        [HttpPost]
        public IActionResult HardDelete(PolicyType policyType) 
        {
            _context.PolicyTypes.Remove(policyType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
           var policyType = _context.PolicyTypes.Find(id);
            if (policyType != null)
            {
                policyType.IsDeleted = true;

                _context.PolicyTypes.Update(policyType);

                try
                {
                    _context.SaveChanges();
                    return Ok(policyType);
                }
                catch (Exception ex)
                {
                   // return StatusCode(500, ex.Message);
                    return BadRequest(ex);
                }
             

            }
            else
            {
                return BadRequest("HATA !");
            }
          
        }

        [HttpPost]
        public IActionResult Update(PolicyType policyType) {

            _context.PolicyTypes.Update(policyType);
            _context.SaveChanges();
            return Ok(policyType);
        }

        [HttpPost]
        public IActionResult GetById(int id) 
        {
            return Ok(_context.PolicyTypes.Find(id));
        }
        


    }
}
