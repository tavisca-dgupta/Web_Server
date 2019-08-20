﻿namespace Webserver
{
    public class RouteOperations
    {
        [Method("POST", "/year")]
        public bool IsLeapYear(string requestBody)
        {
            string[] body = requestBody.Split(',');
            string[] data = new string[2];
            int leapYear = 0;
            for (int i = 0; i < body.Length; i++)
            {
                if (body[i].Contains("year"))
                {
                    data = body[i].Split(':');
                    break;
                }
            }
            string[] tempArray = data[1].Split('}');
            int.TryParse(tempArray[0], out leapYear);
            if (leapYear % 100 == 0)
            {
                if (leapYear % 400 == 0)
                    return true;
            }
            else if (leapYear % 4 == 0)
            {
                return true;
            }
            return false;
        }


    }
}
