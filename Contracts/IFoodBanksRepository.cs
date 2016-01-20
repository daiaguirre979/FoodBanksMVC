using System;
using FoodBanksMVC.Models;

namespace FoodBanksMVC.Contracts
{
    public interface IFoodBanksRepository
    {
        HomeModel GetStatistics();
        FoodBanksModel GetFoodBanks( int start = 0, int total = 5 );
        bool CreateFoodBank( FoodBank foodBank );
        FoodBanksModel GetFoodBank( int id );
        bool UpdateFoodBank( FoodBank foodBank );
        bool DeleteFoodBank( int id );
    }
}