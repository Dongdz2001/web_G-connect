using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Business.Utils
{
    public static class AppSettingsProvider
    {
        public static IConfiguration Configuration { get; set; }
    }
}
