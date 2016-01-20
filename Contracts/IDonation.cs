using System;
using System.ComponentModel.DataAnnotations;

namespace FoodBanksMVC.Contracts
{
    public class IDonation
    {
        int Id { get; set; }
        [Required, MaxLength( 50 )]
        string Item { get; set; }
        [Required]
        int Quantity { get; set; }
        [Required]
        int Quality { get; set; }
        DateTime Created { get; set; }
        [MaxLength( 75 )]
        string FoodBankName { get; set; }
        [MaxLength( 150 )]
        string VolunteerName { get; set; }
    }
}