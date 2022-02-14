using MVCAuthentication_0.AuthenticationClasses;
using MVCAuthentication_0.DesignPatterns.SingletonPattern;
using MVCAuthentication_0.Models.Context;
using MVCAuthentication_0.Models.Entities;
using MVCAuthentication_0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentication_0.Controllers
{
    public class AuthController : Controller
    {

        //Migrate olmadan Veritabanının Code First ile olusturabilmesi icin Entity Framework'un veritabanındaki bir tabloya herhangi bir istek göndermesi yeterlidir...

        MyContext _db;

        public AuthController()
        {
            _db = DBTool.DBInstance;
        }


        public ActionResult ListUsers()
        {
            AuthVM avm = new AuthVM
            {
                AppUsers = _db.AppUsers.ToList()
            };

            return View(avm);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            AppUser ap = _db.AppUsers.FirstOrDefault(x => x.UserName == appUser.UserName && x.Password == appUser.Password);

            if (ap != null)
            {
                if (ap.Role == Models.Enums.UserRole.Admin)
                {
                    Session["admin"] = ap;
                    return RedirectToAction("Index", "Auth");
                }
                ViewBag.Message = "Yetkiniz admin degil";
                return View();
            }

            ViewBag.Message = "Böyle bir kullanıcı bulunamadı";
            return View();
         }


        [AdminAuthentication]
        public ActionResult Index()
        {
            return View();
        }
    }
}