﻿using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.JT.Common.Tenant
{
    public class TenantStore : ITenantStore
    {
        public TenantStore()
        {
           
        }

        public TenantInfo Find(int tenantId)
        {
            throw new Exception("Multi tenant store do implement yet.");
        }

        public TenantInfo Find(string tenancyName)
        {
            throw new Exception("Multi tenant store do implement yet.");
        }
    }
}
