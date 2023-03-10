using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrokersPortalsV1.Models
{
    public class Motor
    {

        [DisplayName("Broker Id")]
        public string? brokerId { get; set; }
        [DisplayName("Product Name")]
        public string? productName { get; set; } = "Motor Policy";
        [Required]
        [DisplayName("Type Of Cover")]
        public string? typeOfCover { get; set; }
        [DisplayName("Insured Name")]
        [Required]
        public string? insuredName { get; set; }
        [DisplayName("Occupation")]
        [Required]
        public string? occupation { get; set; }
        [DisplayName("EmailAddress")]
        [Required]
        public string? emailAddress { get; set; }
        [DisplayName("Vehicle Make")]
        [Required]
        public string? vehicleMake { get; set; }
        [DisplayName("Year Of Make")]
        [Required]
        public string? yearOfMake { get; set; }
        [DisplayName("Insurance Start Date")]
        [Required]
        public DateTime insuranceStartDate { get; set; }
        [DisplayName("Vehicle Value")]
        [Required]
        public decimal vehicleValue { get; set; } 

        public DateTime startDate { get; set; }=DateTime.Now; 

        public Decimal insuredValue { get; set; } = 0;

        [DisplayName("Mode Of Payment")]
        [Required]
        public string? modeOfPayment { get; set; }
        [DisplayName("PolicyHolder")]
        [Required]
        public string? policyHolder { get; set; }
        [DisplayName("Mobile")]
        [Required]
        public string? mobile { get; set; }
        [DisplayName("Address")]
        [Required]
        public string? address { get; set; }
        [DisplayName("Type Of Usage")]
        [Required]
        public string? typeOfUsage { get; set; }
        [DisplayName("Registration Number")]
        [Required]
        public string? registrationNumber { get; set; }
        [DisplayName("Premium Rate")]
        [Required]
        public int premiumRate { get; set; }
        [DisplayName("Cover Period")]
        [Required]
        public int coverPeriod { get; set; }
        [DisplayName("Transaction Date")]
        [Required]
        public DateTime transactionDate { get; set; }
        [DisplayName("Premium")]
        [Required]
        public decimal premium { get; set; }
        [DisplayName("Valid Id")]
        [Required]
        public string? idUploadUrl { get; set; }
        [DisplayName("Utility Bill")]
        [Required]
        public string? utilityBillUploadUrl { get; set; }
        [DisplayName("vehicle License")]
        [Required]
        public string? vehicleLicenseUploadUrl { get; set; }
        public int packageId { get; set; } = 0;

    }
}
