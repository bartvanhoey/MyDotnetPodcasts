using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotnetPodcasts
{
    public static class Config
    {
        public static bool Desktop
        {
            get
            {
#if WINDOWS || MACCATALYST
return true;
#else
                return false;
#endif
            }
        }

        public static string BaseWeb = $"{Base}:5002/";
        public static string Base = "";
        public static string APIUrl = "https://e2c1-2a02-810d-9f00-4d4-bcbe-f1ea-ede7-f3da.ngrok.io/v1/"; // 5000
        public static string ListenTogetherUrl = "https://6466-2a02-810d-9f00-4d4-bcbe-f1ea-ede7-f3da.ngrok.io/listentogether"; //5001

    }
}
