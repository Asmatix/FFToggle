using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFToggle
{
    public class Config : IConfig
    {
        [Description("Whether or not to enable FFToggle.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not to enable FFToggle debug logs.")]
        public bool Debug { get; set; } = false;
    }
}
