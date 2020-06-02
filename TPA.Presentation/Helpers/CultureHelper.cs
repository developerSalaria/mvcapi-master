using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;

namespace TPA.Presentation
{
    public class CultureHelper
    {
        public static string CurrentCulture
        {
            get
            {
              return Thread.CurrentThread.CurrentUICulture.Name;
            }
        }

        public static int CurrentCultureId
        {
            get
            {
                if(Thread.CurrentThread.CurrentUICulture.Name== "en-US")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public static bool IsEnglishCulture
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string DateFormat
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return "MM/dd/yyyy";
                }
                else
                {
                    return "dd/MM/yyyy";
                }
            }
        }

        public static string DateTimeFormat
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return "MM/dd/yyyy HH:MM";
                }
                else
                {
                    return "dd/MM/yyyy HH:MM";
                }
            }
        }

        public static string DateFormatCalinder
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return "mm/dd/yyyy";
                }
                else
                {
                    return "dd/mm/yyyy";
                }
            }
        }

        public static string DateFormatForJavascript
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return "MM/DD/YYYY";
                }
                else
                {
                    return "DD/MM/YYYY"; 
                }
            }
        }

        public static string DateTimeFormatForJavascript
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return "MM/DD/YYYY HH:MM";
                }
                else
                {
                    return "DD/MM/YYYY HH:MM";
                }
            }
        }
    }
} 
