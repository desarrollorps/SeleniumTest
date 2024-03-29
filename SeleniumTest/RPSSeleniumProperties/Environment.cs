﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties
{
    public static class RPSEnvironment
    {
        static RPSEnvironment()
        {
            DefaultWaitSeconds = 90;
            Visible = true;
        }

        public static string RPSBaseURL { get; set; }        
        public static string DefaultUser { get; set; }
        public static string DefaultPassword { get; set; }
        public static string DefaultCodCompany { get; set; }
        public static int DefaultWaitSeconds { get; set; }
        public static bool Visible { get; set; }
    }
}
