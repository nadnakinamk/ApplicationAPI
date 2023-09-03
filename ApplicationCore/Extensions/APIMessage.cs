using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Extensions
{
    public static class APIMessage
    {

        public static string Message(string result)
        {
            string str = "";
            if(result.Contains("SAVED"))
            {
                str= "SUCCESS";
            }
            else if (result.Contains("UPDATED"))
            {
                str = "UPDATED";
            }
            else             
            {
                str = "Process Failed";
            }
            return str;

        }

    }
}
