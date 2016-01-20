using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBanksMVC.Contracts
{
    public interface IHomeModel
    {
        int TotalDonations { get; set; }
        int TotalVolunteers { get; set; }
        int TotalFoodBanks { get; set; }
    }
}
