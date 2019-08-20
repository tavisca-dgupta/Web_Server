using System;

namespace Webserver
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodAttribute : Attribute
    {
        public string type { get; set; }
        public string method { get; set; }
        public MethodAttribute(string type, string method)
        {
            this.type = type;
            this.method = method;
        }

      
    }
}
