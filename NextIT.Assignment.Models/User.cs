using System.ComponentModel.DataAnnotations;

namespace NextIT.Assignment.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}