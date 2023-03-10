using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrokersPortalsV1.Models
{
    public class FleetMotor
    {
        [Required]
        [DisplayName("Vehicle List")]
        public string? VehicleList { get; set; }
        [Required]
        [DisplayName("Proposed Rate")]
        public string? ProposedRate { get; set; }
        [Required]
        [DisplayName("Comment")]
        public string? Comment { get; set; }
        
    }
}
