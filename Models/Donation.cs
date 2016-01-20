using System;
using System.ComponentModel.DataAnnotations;
using FoodBanksMVC.Contracts;

namespace FoodBanksMVC.Models
{
    public class Donation : IDonation
    {
        /// <summary>Unique identifier.</summary>
        public int Id { get; set; }

        /// <summary>Type of item that is donated. (Example: Sweater, desk, can goods, etc.)</summary>
        [Required( ErrorMessage = "required." ), MaxLength( 50 )]
        public string Item { get; set; }

        /// <summary>Number of items donated.</summary>
        [Required(ErrorMessage = "required.")]
        public int Quantity { get; set; }

        /// <summary>Quality of the item. (1-10)</summary>
        [Required( ErrorMessage = "required." )]
        public int Quality { get; set; }

        /// <summary>Date donation happened.</summary>
        public DateTime Created { get; set; }

        /// <summary>Id of the volunteer whom accepted the donation.</summary>
        [Required( ErrorMessage = "required." )]
        public int VolunteerId { get; set; }

        /// <summary>Id of the food bank the item was donated to.</summary>
        [Required( ErrorMessage = "required." )]
        public int FoodBankId { get; set; }

        /// <summary>Name of food bank donation was received.</summary>
        [MaxLength( 75 )]
        public string FoodBankName { get; set; }

        /// <summary>Name of volunteer whom received the donation.</summary>
        [MaxLength( 150 )]
        public string VolunteerName { get; set; }

        public Donation()
        {
        }
    }
}