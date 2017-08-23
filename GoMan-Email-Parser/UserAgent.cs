using System;

namespace Email_Url_Parser
{
    public class UserAgent
    {
        public static string  GenerateUserAgent()
        {
            string[] arrBrowsers = {  "Firefox/0."+randInt(7,9)+"."+randInt(0,5),
                "Outlook-Express/" + randInt(5,8) + "." + randInt(0,5),
                "Opera/"+randInt(7,9) + "." + randInt(1,80),
                "Safari/4"+randInt(1,15) + "." + randInt(1,6),
                "Arora/0."+randInt(1,5),
                "Gecko/200"+randInt(0,9024)+"Firefox/3."+randInt(1,6),
                "Lynx/2."+randInt(1,8)+"."+randInt(2,5)+"dev."+randInt(1,16),
                "Chrome/1.0."+randInt(0,154)+"."+randInt(0,60)};
            string[] arrOS = {  "Windows NT 5.1",
                "Windows NT 6.1",
                "Windows NT 6.0",
                "Windows",
                "Windows 95",
                "Windows 98",
                "FreeBSD i686",
                "Ubuntu i686",
                "Macintosh",
                "Linux"};
            string[] arrPlugins = {    "MS-RTC LM "+randInt(4,8)+";",
                "Win64;",
                "x64;",
                "Trident/"+randInt(4,6)+".0;",
                "SLCC2;",
                ".NET CLR "+randInt(2,4)+"."+randInt(1,7)+".30"+randInt(50,500)+";",
                "Media Center PC "+randInt(0,6)+".0;",
                "Tablet PC "+randInt(1,3)+".0;",
                "Presto/2."+randInt(0,2)+"."+randInt(0,9),
                "rv:1."+randInt(1,5)+"."+randInt(1,9)+";",
                "WOW64;",
                "GTB"+randInt(5,7)+";",
                "WebTV/2."+randInt(0,9)+";",
                "AppleWebKit/"+randInt(500,550)+"."+randInt(1,50)+" (KHTML, like Gecko)",
                "Zune "+randInt(1,4)+".0;",
                "msn OptimizedIE"+randInt(5,8)+";",
                "OfficeLiveConnector.1."+randInt(1,9)+";",
                "OfficeLivePatch.0."+randInt(0,5)+";",
                "AskTB5."+randInt(0,7),
                "MS-RTC LM "+randInt(5,8)+";",
                "InfoPath."+randInt(1,4)+";",
                ".NET"+randInt(2,4)+".0C;"};
            string strPlugins = String.Empty;
            int plugincount = randInt(3, 6);
            int[] history = new int[plugincount];
            for (int i = 0; i != plugincount; i++)
            {
                int ran = randInt(0, arrPlugins.Length);
                if (!int_in_array(history, ran))
                {
                    history[i] = ran;
                    strPlugins = strPlugins + " " + arrPlugins[ran];
                }
                else
                {
                    i--;
                }
            }
            string Type = "Mozilla/" + randInt(2, 5) + ".0";
            string OS = arrOS[randInt(0, arrOS.Length)];
            string[] arrCompatible = { "compatible; MSIE " + randInt(6, 10) + ".0; ", "", "" };
            string Compatible = arrCompatible[randInt(0, 1)];
            if (OS.IndexOf("Linux") != -1 || OS.IndexOf("Ubuntu") != -1 || OS.IndexOf("FreeBSD") != -1 || OS.IndexOf("Macintosh") != -1) { Compatible = ""; } //remove the compatible MSIE message from the string
            return Type + " (" + Compatible + OS + ";" + strPlugins + " " + arrBrowsers[randInt(0, arrBrowsers.Length)] + " )";
        }


        //random number
        private static int randInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //check if a certain value is in any of the array elements
        private static bool int_in_array(int[] array, int value)
        {
            for (int i = 0; i != array.Length; i++)
            {
                if (array[i] == value) { return true; }
            }
            return false;
        }
    }
}
