using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BrokersPortalsV1.Models
{
    public class UserLoginViewModel
    {
        [Required]
        [DisplayName("Company Id")]
        public string? CompanyId { get; set; }
        [Required]
        [DisplayName("User Id")]
        public string? UserId { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
