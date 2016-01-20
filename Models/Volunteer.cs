using System;
using System.ComponentModel.DataAnnotations;
using FoodBanksMVC.Contracts;

namespace FoodBanksMVC.Models
{
    public class Volunteer : IVolunteer
    {
        public int Id { get; set; }

        [Required, MaxLength( 150 )]
        public string Name { get; set; }

        [Required]
        [DataType( DataType.Date )]
        [DisplayFormat( DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true )]
        public DateTime DateOfBirth { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public int FoodBankId { get; set; }

        public string FoodBankName { get; set; }

        public Volunteer()
        {}
    }
}