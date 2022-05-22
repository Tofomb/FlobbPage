using System.ComponentModel.DataAnnotations;

namespace FlobbPage.Models
{
    public class Person
    {
        [Key]
        public string Id { get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }
        

    }
}
