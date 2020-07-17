using Abp.Authorization;
using Abp.Dependency;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Backend.JTAuthenticate
{
    public class JTAuthenticateHelper : IJTAuthenticateHelper, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        public JTAuthenticateHelper(IAbpSession abpSession)
        {
            AbpSession = NullAbpSession.Instance;
        }

        public void Authenticate(MethodInfo methodInfo, Type type)
        {
            if (!methodInfo.IsPublic && !methodInfo.GetCustomAttributes().OfType<IJTAuthenticateAttribute>().Any()) { return; }
            var attr = methodInfo.GetCustomAttributes().OfType<IJTAuthenticateAttribute>().FirstOrDefault();
            if (attr == null) { return; }
            var userid = AbpSession.UserId;
            if (!userid.HasValue)
            {
                throw new Abp.Authorization.AbpAuthorizationException("权限不足");
            }
        }
    }
}
