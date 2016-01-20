using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBanksMVC.Models;
using FoodBanksMVC.Repository;

namespace FoodBanksMVC.Controllers
{
    public class FoodBanksController : Controller
    {

        [Route( "FoodBanks/" )]
        public ActionResult Index()
        {
            var repository = new FoodBanksRepository();
            var model = repository.GetFoodBanks();

            return View( "Index", model );
        }

        [Route( "FoodBanks/PageFoodBanks" )]
        public PartialViewResult PageFoodBanks( int offSet = 0, int limit = 5 )
        {
            var repository = new FoodBanksRepository();
            var model = repository.GetFoodBanks( offSet, limit );

            return PartialView( "Partials/FoodBanksTable", model );
        }

        [Route( "FoodBanks/CreateFoodBank" )]
        public PartialViewResult CreateFoodBank( FoodBank foodBank )
        {
            var repository = new FoodBanksRepository();
            repository.CreateFoodBank( foodBank );
            var model = repository.GetFoodBanks();

            return PartialView( "Partials/FoodBanksTable", model );
        }

        [Route( "FoodBanks/GetFoodBankForEdit" )]
        public PartialViewResult GetFoodBankForEdit( int id )
        {
            var repository = new FoodBanksRepository();
            var model = repository.GetFoodBank( id );

            return PartialView( "Partials/FoodBank", model );
        }

        [Route( "FoodBanks/UpdateFoodBank" )]
        public PartialViewResult UpdateFoodBank( FoodBank foodBank )
        {
            var repository = new FoodBanksRepository();
            repository.UpdateFoodBank( foodBank );
            var model = repository.GetFoodBank( foodBank.Id );

            return PartialView( "Partials/FoodBankTableRow", model.FoodBank );
        }

        [Route( "FoodBanks/DeleteFoodBank" )]
        public bool DeleteFoodBank(int id)
        {
            var repository = new FoodBanksRepository();
            return repository.DeleteFoodBank( id );
        }
    }
}