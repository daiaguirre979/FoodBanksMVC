using System;
using System.Collections.Generic;
using FoodBanksMVC.Models;

namespace FoodBanksMVC.Contracts
{
    public interface IFoodBanksModel
    {
        List<FoodBank> FoodBanks { get; set; }
        FoodBank FoodBank { get; set; }
    }
}