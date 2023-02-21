using BrokersPortalsV1.Enum;
using Newtonsoft.Json;
using System.Data;

namespace BrokersPortalsV1.Class
{
    public class UserPermissionTo : IUserPermission
    {
        private readonly ISessionHandler _sessionHandler;
        public UserPermissionTo(ISessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler; 
        }
            
        public void initialize()
        {
            var roleAccessMatrixTemp = new Dictionary<string?, bool>();
            //SessionHandler _sessionHandler = new SessionHandler();

            Root UserDetails = _sessionHandler.getSession<Root>(SessionVariable.LOGGEDUSER);


            foreach (var roleAccess in UserDetails.roles)
            {
                var userpermision = roleAccess.userPermissions;
                foreach (var module in userpermision)
                {
                    var Usermodule = module.moduleName;
                    if (roleAccessMatrixTemp.ContainsKey(Usermodule.ToString()))
                    {
                        // what should we do?
                    }
                    else
                    {
                        roleAccessMatrixTemp[module.moduleName.ToString()] = true;
                    }

                }
            }

            //Add submodule
            foreach (var roleAccess in UserDetails.roles)
            {
                var userpermision = roleAccess.userPermissions;
                foreach (var module in userpermision)
                {
                    var Usermodule = module.moduleName;
                    foreach (var userProcess in module.userProcesses)
                    {
                        //var subModule = userProcess.forms;
                        foreach (var subModule in userProcess.forms)
                        {
                            roleAccessMatrixTemp[subModule.formName + UserActionType.canCreate.ToString()] = (bool)subModule.canCreate;
                            roleAccessMatrixTemp[subModule.formName + UserActionType.canView.ToString()] = (bool)subModule.canView;
                            roleAccessMatrixTemp[subModule.formName + UserActionType.canEdit.ToString()] = (bool)subModule.canEdit;
                            roleAccessMatrixTemp[subModule.formName + UserActionType.canDelete.ToString()] = (bool)subModule.canDelete;
                        }
                    }

                }
            }

            _sessionHandler.setSession(SessionVariable.USERROLES, roleAccessMatrixTemp);

        }

        //Module
        public bool HasPermission(string moduleName)
        {
            bool haspermission = false;
            var roleAccessMatrix = new Dictionary<string?, bool>(); 

            Dictionary<string?, bool> UserRoles = _sessionHandler.getSessionDic(SessionVariable.USERROLES);

            if (UserRoles.ContainsKey(moduleName))
            {
                haspermission = UserRoles[moduleName];
            }

            return haspermission;
        }
        // Submodul
        public bool HasPermission(string subModuleName, string actionType)
        {
            bool haspermission = false; 
            Dictionary<string?, bool> UserRoles = _sessionHandler.getSessionDic(SessionVariable.USERROLES);


            string subModuleActionType = subModuleName + actionType;
            //Check for module first
            if (UserRoles.ContainsKey(subModuleActionType))
            {
                haspermission = UserRoles[subModuleActionType];
            }
            return haspermission;
        }
        public string EmitCssClass(bool eval, string valueToEmitWhenTrue, string valueToEmitWhenFalse)
        {
            if (eval) return valueToEmitWhenTrue;
            return valueToEmitWhenFalse;
        }
    }
}
