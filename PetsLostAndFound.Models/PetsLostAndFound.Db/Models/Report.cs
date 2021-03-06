﻿namespace PetsLostAndFound.Db.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Db.Models.Enums;

    public class Report
    {
        public Report()
        {
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        // Lost or Found
        [Required]
        public StatusType Status { get; set; }

        // Connection with the author 
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        // Comments on the post
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// A date specifying when the pet was lost
        /// </summary>
        public DateTime LostDate { get; set; }

        /// <summary>
        /// A place to store the images for the given post 
        /// Maybe use a diffrent way to store them 
        /// </summary>
        public string ImagesLinksPost { get; set; }

        /// <summary>
        /// A field where a user can decide if they want to give money to the one who finds it 
        /// </summary>
        public double? RewardSum { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        /// <summary>
        /// A general text field which gives the user the ability to add more details about how , where the pet was lost
        /// </summary>
        public string Content { get; set; }

        public int LocationId { get; set; }

        [Required]
        public Location Location { get; set; }
    }
}