using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FoodBanksMVC.Models
{
    public class VolunteersModel
    {
        public List<Volunteer> Volunteers { get; set; }
        public Volunteer Volunteer { get; set; }
        public List<Link> Links { get; set; }
        public int TotalVolunteers { get; set; }
        public List<FoodBank> FoodBanks { get; set; }

        public VolunteersModel()
        {
            Volunteers = new List<Volunteer>();
            Volunteer = new Volunteer();
            Links = new List<Link>();
            FoodBanks = new List<FoodBank>();
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
                if ( Volunteer != null && item.Value == Volunteer.FoodBankId.ToString() )
                    item.Selected = true;

                retVal.Add( item );
            }

            return retVal;
        }
    }
}