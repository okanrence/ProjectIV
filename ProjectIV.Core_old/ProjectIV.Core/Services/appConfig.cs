using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Services
{
    public static class appConfig
    {
        public static string apiBaseUrl { get { return ConfigurationManager.AppSettings["apiBaseUrl"]; } }

    }
}
