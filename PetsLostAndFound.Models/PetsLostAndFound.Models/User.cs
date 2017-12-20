using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetsLostAndFound.Models.Enums;

namespace PetsLostAndFound.Models
{
    public class User
    {
        public User()
        {
            this.Reports = new List<Report>();
            this.Comments = new List<Comment>();
            this.Pets = new List<Pet>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Ginko Grudev: Started addign the barebones decided to use class libraries so it's easier to use it
        /// </summary>
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        // No idea how to store this
        [Required]
        public string Password { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        // The town from which the user is from
        public string TownName { get; set; }

        public string Image { get; set; }

        /// <summary>
        /// Enum for which holds the type of roles , we should decide if we want to use enums or a bool is Admin
        /// </summary>
        public UserType UserType { get; set; }

        // public bool IsAdmin { get; set; }

        /// <summary>
        /// Collection of Locations which a user will have
        /// A GeoCordinate Class in the location or just have it with 2 field for the cordinates
        /// Actually this should be in the posts and a post will have one location or maybe have a collection if we want to make it so one then more position can be sumbited but that would complicate things too much 
        /// </summary>
        // public ICollection<Location> Locations { get; set; }

        /// <summary>
        /// User pets
        /// </summary>
        public ICollection<Pet> Pets { get; set; }

        /// <summary>
        /// A Collection of followers/friends if we want some kind of social networking kind of system
        /// </summary>
        public ICollection<Follower> Followers { get; set; }

        /// <summary>
        /// I think it will be a good idea to have posts and pets so we can separate our logic a bit and the posts whill have pet pet and pet petId which will help us map them
        /// </summary>
        public ICollection<Report> Reports { get; set; }

        /// <summary>
        /// The comments which the user has left under other people's posts
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
    }
}
