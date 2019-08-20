using System;

namespace Webserver
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodAttribute : Attribute
    {
        public MethodAttribute(string Type, string Method)
        {
            this.Type = Type;
            this.Method = Method;
        }

        public string Type { get; set; }
        public string Method { get; set; }
    }
}
