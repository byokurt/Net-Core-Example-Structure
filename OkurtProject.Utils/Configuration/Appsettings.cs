using System;
using System.Collections.Generic;
using System.Text;

namespace OkurtProject.Utils
{
    public class Appsettings
    {
        public string Secret { get; set; }
        public LogSettings LogSettings { get; set; }

        public Appsettings()
        {

        }

        public Appsettings(string secret, LogSettings logSettings)
        {
            Secret = secret;
            LogSettings = logSettings;
        }
    }
}
