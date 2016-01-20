using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBanksMVC.Models;
using FoodBanksMVC.Repository;

namespace FoodBanksMVC.Controllers
{
    public class HomeController : Controller
    {
        [Route( "~/" )]
        public ActionResult Index()
        {
            var repository = new FoodBanksRepository();
            var model = repository.GetStatistics();
            
            return View( "Index", model );
        }

        [Route("About/")]
        public ActionResult About()
        {
            return View("About");
        }
	}
}