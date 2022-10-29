using AppointmentSchedular.AuthenticateFilters;
using AppointmentSchedular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace AppointmentSchedular.Controllers
{

    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        MVCEntity mvc = new MVCEntity();
        [HttpGet]
        public ActionResult Signup()
        {
            
            return View("Signup");
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Signup(MVCEntity pos)
        {
            if (!ModelState.IsValid)
            {
                return View("Signup");
            }
            
            //var user = from u in mvc.Authentications where u.username == pos.username && u.passwords==pos. select u;
            mvc.Entry(pos).State = EntityState.Added;
            //Session["Userkey"] = Guid.NewGuid().ToString();
            return RedirectToAction("Login", "Authenticate");
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Authentication model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = from u in mvc.Authentications where u.username == model.username && u.passwords == model.passwords select u;
            if (user.Count() > 0)
            {
                Session["Userkey"] = Guid.NewGuid().ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            //from u in mvc.Authentications where u.username == model.username && u.passwords == log.passwords select u;
        }
    }
}