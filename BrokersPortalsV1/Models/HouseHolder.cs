using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrokersPortalsV1.Models
{
    public class HouseHolder
    {
        [Required]
        [DisplayName("Property")]
        public string? property { get; set; }
        
        [Required]
        [DisplayName("Type Of Cover")]
        public string? typeOfCover { get; set; }
        [DisplayName("Building Value")]
        [Required]
        public string? valueOfBuilding { get; set; }
        [DisplayName("Location")]
        [Required]
        public string? location { get; set; }
        [DisplayName("Purpose Of Building")]
        [Required]
        public string? purposeOfBuilding { get; set; }
        [DisplayName("Occupiers Liability Insurance")] 
        public string? occupiersLiabilityInsurance { get; set; } 
        [DisplayName("Additional perils")] 
        public string? additionalperils { get; set; } 

    }
}
