using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrokersPortalsV1.Models
{
    public class Motor
    {
        [Required]
        [DisplayName("Insured Name")]
        public string InsuredName { get; set; }
        [DisplayName("Occupation")]
        public string Occupation { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DisplayName("Type Cover")]
        public string TypeCover { get; set; }
        [DisplayName("Make Vehicle")]
        public string MakeVehicle { get; set; }
        [Required]
        [DisplayName("Year Make")]
        public string YearMake { get; set; }
        [DisplayName("Vehicle Value")]
        public int VehicleValue { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("Insured Value")]
        public int InsuredValue { get; set; }
        [DisplayName("Mode Payment")]
        public string ModePayment { get; set; }
        [DisplayName("Policy Holder")]
        public string PolicyHolder { get; set; }
        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Type Usage")]
        public string TypeUsage { get; set; }
        [DisplayName("Reg Number")]
        public int RegNumber { get; set; }
         [DisplayName("Premium Rate")]
        public int PremiumRate { get; set; }
        [DisplayName("Cover Period")]
        public string CoverPeriod { get; set; }
        [DisplayName("Trans Date")]
        public DateTime TransDate { get; set; }
        [DisplayName("Premium")]
        public int Premium { get; set; }
    }
}
