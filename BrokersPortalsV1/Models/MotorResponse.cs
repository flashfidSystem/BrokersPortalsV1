using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrokersPortalsV1.Models
{
    public class MotorResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public string requestId { get; set; }
            public string brokerId { get; set; }
            public string productName { get; set; }
            public string typeOfCover { get; set; }
            public string insuredName { get; set; }
            public string occupation { get; set; }
            public string emailAddress { get; set; }
            public string vehicleMake { get; set; }
            public string yearOfMake { get; set; }
            public DateTime insuranceStartDate { get; set; }
            public int vehicleValue { get; set; }
            public DateTime startDate { get; set; }
            public int insuredValue { get; set; }
            public string modeOfPayment { get; set; }
            public string policyHolder { get; set; }
            public string mobile { get; set; }
            public string address { get; set; }
            public string typeOfUsage { get; set; }
            public string registrationNumber { get; set; }
            public int premiumRate { get; set; }
            public int coverPeriod { get; set; }
            public DateTime transactionDate { get; set; }
            public int premium { get; set; }
            public string idUploadUrl { get; set; }
            public string utilityBillUploadUrl { get; set; }
            public string vehicleLicenseUploadUrl { get; set; }
            public DateTime dateCreated { get; set; }
            public int productId { get; set; }
            public int packageId { get; set; }
        }

        public class Error
        {
        }

        public class Root
        {
            public Error error { get; set; }
            public Data data { get; set; }
        }
    }

}
