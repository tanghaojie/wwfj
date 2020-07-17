using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.JTAuthenticate
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class JTAuthenticateAttribute : Attribute, IJTAuthenticateAttribute
    {
        public JTAuthenticateAttribute()
        {
        }
    }
}
