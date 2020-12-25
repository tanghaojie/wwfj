using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.RunTime
{
    public class AppTimes : ISingletonDependency
    {
        public DateTime StartupTime { get; set; }
    }
}
