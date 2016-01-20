using System;
using FoodBanksMVC.Models;

namespace FoodBanksMVC.Contracts
{
    public interface IVolunteersRepository
    {
        VolunteersModel GetVolunteers( int start = 0, int total = 5 );
         bool CreateVolunteer( Volunteer volunteer );
         VolunteersModel GetVolunteer( int id );
         bool UpdateVolunteer( Volunteer volunteer );
         bool DeleteVolunteer( int id );
    }
}