using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.JT.Common.Tenant
{
    public static class NoneTenancyConsts
    {
        /// <summary>
        /// Abp define tenant id = 1 when disable multi tenant.
        /// </summary>
        public const int DefaultTenantId = MultiTenancyConsts.DefaultTenantId;
        public const string DefaultTenantName = "DefaultSingleTenancyName";
    }
}
