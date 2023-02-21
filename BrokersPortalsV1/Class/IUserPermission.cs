namespace BrokersPortalsV1.Class
{
    public interface IUserPermission
    {

        public void initialize();
        public bool HasPermission(string moduleName);
        public bool HasPermission(string subModuleName, string actionType);
        public string EmitCssClass(bool eval, string valueToEmitWhenTrue, string valueToEmitWhenFalse); 
    }
}
