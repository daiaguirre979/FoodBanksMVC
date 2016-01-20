using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodBanksMVC.Contracts;

namespace FoodBanksMVC.Models
{
    public class HomeModel : IHomeModel    {
        public int TotalDonations { get; set; }
        public int TotalFoodBanks { get; set; }
        public int TotalVolunteers { get; set; }

        public HomeModel()
        {}
    }
}