using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodBanksMVC.Contracts;

namespace FoodBanksMVC.Models
{
    public class FoodBanksModel : IFoodBanksModel
    {
        public List<FoodBank> FoodBanks { get; set; }
        public FoodBank FoodBank { get; set; }
        public List<Link> Links { get; set; }
        public int TotalFoodBanks { get; set; }

        public FoodBanksModel()
        {
            FoodBanks = new List<FoodBank>();
            FoodBank = new FoodBank();
            Links = new List<Link>();
        }
    }
}