using System.ComponentModel.DataAnnotations;

namespace LogicLayer.Models.Identity
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
