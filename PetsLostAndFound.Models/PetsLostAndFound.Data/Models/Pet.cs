namespace PetsLostAndFound.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;
    using System.Collections.Generic;

    public class Pet
    {
        public Pet()
        {
            this.Reports = new List<Report>();
        }

        public int Id { get; set; }

        // Specify the type of pet that has been lost enum for now
        public PetType PetType { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        /// <summary>
        /// Has to be optional 
        /// No idea what datatype to use on this one , but it should be the chip freqency of the pet
        /// </summary>
        public string RFID { get; set; }

        /// <summary>
        /// Maybe have a collection of images for the pets
        /// </summary>
        public string ImageLinks { get; set; }

        public string PetDescription { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<Report> Reports { get; set; }

    }
}