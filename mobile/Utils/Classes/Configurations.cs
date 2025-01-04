﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Utils.Classes
{
    public static class Configurations
    {
        public static bool Get(ConfigurationsEnum config, bool valueIfNotExists = false)
        {
            return Preferences.Get(nameof(config), valueIfNotExists);
        }

        public static void Save(ConfigurationsEnum config, string value)
        {
            Preferences.Set(nameof(config), value);
        }
    }

    public enum ConfigurationsEnum
    {
        DarkMode
    }
}