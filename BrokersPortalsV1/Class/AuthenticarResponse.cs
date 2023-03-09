namespace BrokersPortalsV1.Class
{
    public class AuthenticarResponse
    {
        public Error error { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string userId { get; set; }
        public UserData userData { get; set; }
        public List<ApplicationRole> applicationRoles { get; set; }
    }

    public class Error
    {
    }
    public class ApplicationRole
    {
        public string rolename { get; set; }
        public List<string> modules { get; set; }
        public List<string> processes { get; set; }
        public List<Form> forms { get; set; }
    }
 


    public class Form
    {
        public string formName { get; set; }
        public string moduleName { get; set; }
        public string processName { get; set; }
        public bool canCreate { get; set; }
        public bool canView { get; set; }
        public bool canEdit { get; set; }
        public bool canDelete { get; set; }
    }

    public class ProfileResponse
    {
        public Error error { get; set; }
        public Data data { get; set; }
    }

    public class UserData
    {
        public string userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string companyId { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public bool isActive { get; set; }
        public bool isEmailVerified { get; set; }
        public bool isProfileUpdated { get; set; }
    }


}
