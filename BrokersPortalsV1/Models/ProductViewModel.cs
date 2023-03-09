using BrokersPortalsV1.Class;

namespace BrokersPortalsV1.Models
{
    public class ProductViewModel
    {
        public class data
        {
            public int id { get; set; }
            public string productName { get; set; }
            public string description { get; set; }
        }

        public class Error
        {
        }

        public class Product
        {
            public Error error { get; set; }
            public List<data> data { get; set; }
        }


    }
    public class PackageViewModel
    {
        public class data
        {
            public int id { get; set; }
            public string packageName { get; set; }
        }

        public class Error
        {
        }

        public class Package
        {
            public Error error { get; set; }
            public List<data> data { get; set; }
        }

    }
}
