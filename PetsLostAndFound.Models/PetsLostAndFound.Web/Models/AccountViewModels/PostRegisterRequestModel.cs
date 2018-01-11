namespace PetsLostAndFound.Web.Models.AccountViewModels
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

      public class PostRegisterRequestModel
      {

            [Required]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Phone Number")]
            public string TelephoneNumber { get; set; }
            
            [Display(Name = "Town Name")]
            public string LocationName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            //[DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            //public string ConfirmPassword { get; set; }

            public IEnumerable<string> UserImagesId { get; set; }

            public double Latitude { get; set; }

            public double Longitude { get; set; }
    }
}
