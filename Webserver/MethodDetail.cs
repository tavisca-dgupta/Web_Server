namespace Webserver
{
    public class MethodDetail
    {
        public string GetMethod(string httptype, string method)
        {
            foreach (var prop in typeof(RouteOperations).GetMethods())
            {
                var attributes = (MethodAttribute[])prop.GetCustomAttributes
                    (typeof(MethodAttribute), false);
                foreach (var attr in attributes)
                {

                    if (attr.type == httptype && method == attr.method)
                        return prop.Name;
                }
            }
            return "No Such Method found";
        }
    }
}
