using GarajYeriHI.Data;
using GarajYeriHI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GarajYeriHI.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=_context.Users.Where(u=>!u.IsDeleted).ToList()});
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUser appUser)
        {
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == appUser.UserName && u.Password == appUser.Password);
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
            _context.Users.Add(appUser);
            _context.SaveChanges();
            return Ok(appUser);
        }
        [HttpPost]
        public IActionResult HardDelete(AppUser appUser)
        {
            _context.Users.Remove(appUser);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
           AppUser appUser= _context.Users.Find(id);
            appUser.IsDeleted = true;
            _context.Users.Update(appUser);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(AppUser appUser)
        {
            _context.Users.Update(appUser);
            _context.SaveChanges();
            return Ok(appUser);
        }

     
    }
}
