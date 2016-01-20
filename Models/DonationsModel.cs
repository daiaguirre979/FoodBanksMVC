using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FoodBanksMVC.Models
{
    public class DonationsModel
    {
        public List<Donation> Donations { get; set; }
        public Donation Donation { get; set; }
        public List<Link> Links { get; set; }
        public int TotalDonations { get; set; }

        public List<FoodBank> FoodBanks { get; set; }
        public List<Volunteer> Volunteers { get; set; }

        public DonationsModel()
        {
            Donations = new List<Donation>();
            Donation = new Donation();
            Links = new List<Link>();
            FoodBanks = new List<FoodBank>();
            Volunteers = new List<Volunteer>();
        }

        public List<SelectListItem> GetFoodBanks()
        {
            var retVal = new List<SelectListItem>();

            foreach ( var foodbank in FoodBanks )
            {
                var item = new SelectListItem
                {
                    Text = foodbank.Name,
                    Value = foodbank.Id.ToString()
                };
                if ( Donation != null && item.Value == Donation.FoodBankId.ToString() )
                    item.Selected = true;

                retVal.Add( item );
            }

            return retVal;
        }

        public List<SelectListItem> GetVolunteers()
        {
            var retVal = new List<SelectListItem>();

            foreach ( var volunteer in Volunteers )
            {
                var item = new SelectListItem
                {
                    Text = volunteer.Name,
                    Value = volunteer.Id.ToString()
                };
                if ( Donation != null && item.Value == Donation.VolunteerId.ToString() )
                    item.Selected = true;

                retVal.Add( item );
            }

            return retVal;
        }
    }
}