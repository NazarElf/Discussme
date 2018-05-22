using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using Discussme.PL.Models;
using Discussme.BLL.DbObjects;
using Discussme.BLL.ServiceInterfaces;

namespace Discussme.PL.Controllers
{
    public class AccountController : Controller
    {
        private IForumService ForumService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IForumService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await ForumService.SetInitData(new UserB
            {
                Email = "nnn43@ukr.net",
                Nickname = "Rover_Go",
                Password = "Somebody4_4Someone",
                Firstname = "Nazar",
                Lastname = "Yurchenko",
                UserRole = "admin",
                UserPrivacy = "public",
            }, new List<string> { "user", "admin" });

            if(ModelState.IsValid)
            {
                UserB userB = new UserB { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await ForumService.Authenticate(userB);
                if(claim == null)
                {
                    ModelState.AddModelError("", "Wrong Password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await ForumService.SetInitData(new UserB
            {
                Email = "nnn43@ukr.net",
                Nickname = "Rover_Go",
                Password = "Somebody4_4Someone",
                Firstname = "Nazar",
                Lastname = "Yurchenko",
                UserRole = "admin",
                UserPrivacy = "public",
            }, new List<string> { "user", "admin" });

            if (ModelState.IsValid)
            {
                UserB userDto = new UserB
                {
                    Email = model.Email,
                    Password = model.Password,
                    Nickname = model.Nickname,
                    UserRole = "user"
                };
                OperationDetails operationDetails = await ForumService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }
}