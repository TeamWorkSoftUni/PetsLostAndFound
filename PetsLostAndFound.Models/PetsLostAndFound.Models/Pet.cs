using System;
using System.ComponentModel.DataAnnotations;
using PetsLostAndFound.Models.Enums;

namespace PetsLostAndFound.Models
{
    public class Pet
    {
        public int Id { get; set; }

        // Specify the type of pet that has been lost enum for now
        public PetType PetType { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        /// <summary>
        /// Maybe have a collection of images for the pets
        /// </summary>
        public string[] ImageLinks { get; set; }

        public string PetDescription { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

    }
}