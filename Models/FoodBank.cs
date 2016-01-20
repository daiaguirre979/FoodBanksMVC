using System;
using System.ComponentModel.DataAnnotations;
using FoodBanksMVC.Contracts;

namespace FoodBanksMVC.Models
{
    public class FoodBank : IFoodBank
    {
        /// <summary>Unique identifier.</summary>
        public int Id { get; set; }

        /// <summary>Full name.</summary>
        [Required, MaxLength( 75 )]
        public string Name { get; set; }

        /// <summary>Address.</summary>
        [Required, MaxLength( 75 )]
        public string Addr1 { get; set; }

        /// <summary>Address continued. </summary>
        [MaxLength( 50 )]
        public string Addr2 { get; set; }

        /// <summary>City. </summary>
        [Required, MaxLength( 45 )]
        public string City { get; set; }

        /// <summary>State </summary>
        [Required, MaxLength( 2 )]
        public string State { get; set; }

        /// <summary>Postal code. </summary>
        [Required, MaxLength( 12 )]
        public string Postal { get; set; }

        /// <summary>Date food bank was created. </summary>
        public DateTime Created { get; set; }

        /// <summary>Total number of volunteers assigned to this food bank.</summary>
        public int VolunteerCount { get; set; }

        /// <summary>Total number of donations received at this food bank.</summary>
        public int DonationCount { get; set; }

        public FoodBank()
        {
        }
    }
}