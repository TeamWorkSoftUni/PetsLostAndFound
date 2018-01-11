namespace PetsLostAndFound.Web.Models.AccountViewModels
{
  using System.ComponentModel.DataAnnotations;

  public class PostLoginRequrestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
