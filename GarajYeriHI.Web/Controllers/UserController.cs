using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GarajYeriHI.Web.Controllers
{
    public class UserController : Controller
    {
       private readonly IRepository<AppUser> _appUserRepository;

        public UserController(IRepository<AppUser> appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=_appUserRepository.GetAll()});
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUser appUser)
        {
            AppUser user = _appUserRepository.GetFirstOrDefault(u => u.UserName == appUser.UserName && u.Password == appUser.Password);
            if(user!=null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name,user.UserName));
                claims.Add(new Claim(ClaimTypes.GivenName, user.FullName));
                claims.Add(new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"));
                ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

              await  HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


               await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Vehicle");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            


            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Add(AppUser appUser)
        {
            return Ok(_appUserRepository.Add(appUser));
        }
       

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            _appUserRepository.DeleteById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(AppUser appUser)
        {
         
            return Ok(_appUserRepository.Update(appUser));
        }

        [HttpPost]
        public IActionResult GetById(int id) {

            return Ok(_appUserRepository.GetById(id));
        }

     
    }
}
