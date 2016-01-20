using System;
using System.ComponentModel.DataAnnotations;

namespace FoodBanksMVC.Contracts
{
    public interface IVolunteer
    {
        int Id { get; set; }

        [Required, MaxLength( 150 )]
        string Name { get; set; }

        [Required, DisplayFormat( DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true )]
        DateTime DateOfBirth { get; set; }

        DateTime Created { get; set; }

        [Required]
        int FoodBankId { get; set; }

        string FoodBankName { get; set; }
    }
}