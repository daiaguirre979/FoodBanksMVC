using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodBanksMVC.Contracts;

namespace FoodBanksMVC.Repository
{
    public class Statistics : IStatistics
    {
        public int TotalDonations { get; set; }
        public int TotalVolunteers { get; set; }
        public int TotalFoodBanks { get; set; }
    }
}