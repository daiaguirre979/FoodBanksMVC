using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodBanksMVC.Models;

namespace FoodBanksMVC.Contracts
{
    public interface IDonationssRepository
    {
        DonationsModel GetDonations( int start = 0, int total = 5 );
        bool CreateDonation( Donation donation );
        DonationsModel GetDonation( int id );
        bool UpdateDonation( Donation Donation );
        bool DeleteDonation( int id );
    }
}