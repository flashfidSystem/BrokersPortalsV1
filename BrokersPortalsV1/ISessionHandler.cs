﻿namespace BrokersPortalsV1
{
    public interface ISessionHandler
    {
        public T getSession<T>(SessionVariable sessionVariable);
        public Dictionary<string, bool> getSessionDic(SessionVariable sessionVariable);
        public void setSession(SessionVariable sessionVariable, object value);
        public void setLogOut();
    }
}
