using System;
using System.ComponentModel.DataAnnotations;

namespace FoodBanksMVC.Contracts
{
    public interface IFoodBank
    {
        /// <summary>Unique identifier.</summary>
        int Id { get; set; }

        /// <summary>Full name.</summary>
        [Required, MaxLength( 75 )]
        string Name { get; set; }

        /// <summary>Address. </summary>
        [Required, MaxLength( 75 )]
        string Addr1 { get; set; }

        /// <summary>Address continued. </summary>
        [MaxLength( 50 )]
        string Addr2 { get; set; }

        /// <summary>City. </summary>
        [Required, MaxLength( 45 )]
        string City { get; set; }

        /// <summary>State </summary>
        [Required, MaxLength( 2 )]
        string State { get; set; }

        /// <summary>Postal code. </summary>
        [Required, MaxLength( 12 )]
        string Postal { get; set; }

        /// <summary>Date food bank was created. </summary>
        DateTime Created { get; set; }

        /// <summary>Total number of volunteers assigned to this food bank.</summary>
        int VolunteerCount { get; set; }

        /// <summary>Total number of donations received at this food bank.</summary>
        int DonationCount { get; set; }
    }
}