using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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


    public class UserResponse
    {
        [Key]
        [JsonIgnore]
        public int UserId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? City { get; set; }

    }
}
