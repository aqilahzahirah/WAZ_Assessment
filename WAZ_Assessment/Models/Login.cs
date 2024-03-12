using System.ComponentModel.DataAnnotations;

namespace WAZ_Assessment.Models
{
    public class Login
    {
        [Key]
        [MinLength(5)]
        public string Username { get; set; }

        [MinLength(5)]
        public string Password { get; set; }
    }
}
