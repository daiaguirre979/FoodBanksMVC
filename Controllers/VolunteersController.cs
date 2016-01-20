using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBanksMVC.Models;
using FoodBanksMVC.Repository;

namespace FoodBanksMVC.Controllers
{
    public class VolunteersController : Controller
    {
        [Route( "Volunteers/" )]
        public ActionResult Index()
        {
            var repository = new VolunteersRepository();
            VolunteersModel model = repository.GetVolunteers();
            if ( model != null )
                model.FoodBanks = new FoodBanksRepository().GetFoodBanks( 0, 1000 ).FoodBanks;

            return View( "Index", model );
        }

        [Route( "Volunteers/PageVolunteers" )]
        public PartialViewResult PageVolunteers( int offSet = 0, int limit = 5 )
        {
            var repository = new VolunteersRepository();
            var model = repository.GetVolunteers( offSet, limit );

            return PartialView( "Partials/VolunteersTable", model );
        }

        [Route( "Volunteers/CreateVolunteer" )]
        public PartialViewResult CreateVolunteer( Volunteer volunteer )
        {
            var repository = new VolunteersRepository();
            repository.CreateVolunteer( volunteer );
            var model = repository.GetVolunteers();
            
            return PartialView( "Partials/VolunteersTable", model );
        }

        [Route( "Volunteers/GetVolunteerForEdit" )]
        public PartialViewResult GetVolunteerForEdit( int id )
        {
            var repository = new VolunteersRepository();
            var model = repository.GetVolunteer( id );
            if ( model != null )
                model.FoodBanks = new FoodBanksRepository().GetFoodBanks( 0, 1000 ).FoodBanks;

            return PartialView( "Partials/Volunteer", model );
        }
        
        [Route( "Volunteers/UpdateVolunteer" )]
        public PartialViewResult UpdateVolunteer( Volunteer volunteer )
        {
            var repository = new VolunteersRepository();
            repository.UpdateVolunteer( volunteer );
            var model = repository.GetVolunteer( volunteer.Id );

            return PartialView( "Partials/VolunteerTableRow", model.Volunteer );
        }

        [Route( "Volunteers/DeleteVolunteer" )]
        public bool DeleteVolunteer( int id )
        {
            var repository = new VolunteersRepository();
            return repository.DeleteVolunteer( id );
        }
    }
}