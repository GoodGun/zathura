using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Core.Helper;
using Zathura.Core.Infrastructure;
using Zathura.Data.Model;

namespace Zathura.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region User
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userExists =
                _userRepository.GetMany(x => x.Email == user.Email && x.Password == user.Password && x.Status == (int)Status.Active)
                    .SingleOrDefault();
            if (userExists != null) 
            {
                if (userExists.Role.Name == Roles.Admin)
                {
                    Session["UserEmail"] = userExists.Email;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Unauthorized User!!!";
            }
            ViewBag.Message = "User does not exists!!!";
            return View();
        }
    }
}