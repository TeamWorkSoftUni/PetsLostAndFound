namespace PetsLostAndFound.Db.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Db.Models.Enums;
    using System.Collections.Generic;

    public class Pet
    {
        public Pet()
        {
            this.Reports = new List<Report>();
        }

        public int Id { get; set; }
        
        public PetType PetType { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }
        
        public string RFID { get; set; }
        
        public string PetDescription { get; set; }

        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}