using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodBanksMVC.Models;
using FoodBanksMVC.Repository;

namespace FoodBanksMVC.Controllers
{
    public class DonationsController : Controller
    {
        [Route( "Donations/" )]
        public ActionResult Index()
        {
            var repository = new DonationsRepository();
            var model = repository.GetDonations();
            if ( model != null )
            {
                model.FoodBanks = new FoodBanksRepository().GetFoodBanks( total: 1000 ).FoodBanks;
                model.Volunteers = new VolunteersRepository().GetVolunteers( total: 1000 ).Volunteers;
            }

            return View( "Index", model );
        }

        [Route( "Donations/PageDonations" )]
        public PartialViewResult PageDonations( int offSet = 0, int limit = 5 )
        {
            var repository = new DonationsRepository();
            var model = repository.GetDonations( offSet, limit );

            return PartialView( "Partials/DonationsTable", model );
        }

        [Route( "Donations/CreateDonation" )]
        public PartialViewResult CreateDonation( Donation Donation )
        {
            var repository = new DonationsRepository();
            repository.CreateDonation( Donation );
            var model = repository.GetDonations();
            
            return PartialView( "Partials/DonationsTable", model );
        }

        [Route( "Donations/GetDonationForEdit" )]
        public PartialViewResult GetDonationForEdit( int id )
        {
            var repository = new DonationsRepository();
            var model = repository.GetDonation( id );
            if ( model != null )
            {
                model.FoodBanks = new FoodBanksRepository().GetFoodBanks( total: 1000 ).FoodBanks;
                model.Volunteers = new VolunteersRepository().GetVolunteers( total: 1000 ).Volunteers;
            }

            return PartialView( "Partials/Donation", model );
        }

        [Route( "Donations/UpdateDonation" )]
        public PartialViewResult UpdateDonation( Donation Donation )
        {
            var repository = new DonationsRepository();
            repository.UpdateDonation( Donation );
            var model = repository.GetDonation( Donation.Id );

            return PartialView( "Partials/DonationTableRow", model.Donation );
        }

        [Route( "Donations/DeleteDonation" )]
        public bool DeleteDonation( int id )
        {
            var repository = new DonationsRepository();
            return repository.DeleteDonation( id );
        }


    }
}