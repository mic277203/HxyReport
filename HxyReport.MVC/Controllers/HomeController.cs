using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HxyReport_MVC.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using HxyReport.Core;

namespace HxyReport_MVC.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly HxyUserManager _UserManager;
        public HomeController(HxyUserManager userManager)
        {
            
            _UserManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Log4Helper.InfoLog("hello");
                Log4Helper.ErrorLog("hello");
            }
           
            var user =await _UserManager.FindByIdAsync(User.Identity.GetUserId());

           return View();
        }
    }
}