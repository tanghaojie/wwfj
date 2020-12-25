using Abp.MultiTenancy;

namespace Abp.JT.Common.Tenant
{
    public class NoneTenantStore : ITenantStore
    {
        public static TenantInfo SingleTenantInfo = new TenantInfo(NoneTenancyConsts.DefaultTenantId, NoneTenancyConsts.DefaultTenantName);
        public NoneTenantStore() { }
        public TenantInfo Find(int tenantId)
        {
            return tenantId == NoneTenancyConsts.DefaultTenantId ? SingleTenantInfo : null;
        }
        public TenantInfo Find(string tenancyName)
        {
            return tenancyName == NoneTenancyConsts.DefaultTenantName ? SingleTenantInfo : null;
        }
    }
}
