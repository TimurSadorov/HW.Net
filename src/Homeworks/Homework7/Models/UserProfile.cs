using System.ComponentModel.DataAnnotations;

namespace Homework7.Models
{
    public enum Sex
    {
        Male,
        Female
    }
    
    public class UserProfile
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        public string? Patronimyc { get; set; }
        [Range(6, 100)]
        public int Age { get; set; }
        public Sex Sex { get; set; }
    }
}