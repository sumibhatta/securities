using System.ComponentModel.DataAnnotations;

namespace Securities.API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? City { get; set; }

    }
}
