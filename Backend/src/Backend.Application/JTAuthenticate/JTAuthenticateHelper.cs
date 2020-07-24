using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Backend.Entities;
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
        public IRepository<User> UserRepository { get; set; }
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
                throw new AbpAuthorizationException("权限不足");
            }
            var user = UserRepository.Get((int)userid.Value);
            if (user == null)
            {
                throw new AbpAuthorizationException("用户不存在");
            }
            if (user.Locked)
            {
                throw new AbpAuthorizationException("当前账号已锁定，请联系管理员解锁账号");
            }
        }
    }
}
