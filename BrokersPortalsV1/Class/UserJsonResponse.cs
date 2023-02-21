namespace BrokersPortalsV1.Class
{

    public class Form
    {
        public string? formName { get; set; }
        public string? formRoute { get; set; }
        public bool? canCreate { get; set; }
        public bool? canView { get; set; }
        public bool? canEdit { get; set; }
        public bool? canDelete { get; set; }
    }

    public class Profile
    {
        public int applicationUserId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? userRole { get; set; }
        public object? streetAddress { get; set; }
        public object? city { get; set; }
        public object? state { get; set; }
        public object? postalCode { get; set; }
        public object? companyId { get; set; }
        public object? company { get; set; }
    }

    public class Role
    {
        public string? roleName { get; set; }
        public List<UserPermission>? userPermissions { get; set; }
    }

    public class Root
    {
        public Profile? profile { get; set; }
        public List<Role>? roles { get; set; }
    }

    public class UserPermission
    {
        public string? moduleName { get; set; }
        public List<UserProcess>? userProcesses { get; set; }
    }

    public class UserProcess
    {
        public string? processName { get; set; }
        public List<Form>? forms { get; set; }
    }


}
