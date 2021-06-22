using OuroborosVandaleriaCore.Engine.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Screen.Dev
{
    public class DevInputCommand : BaseInputCommand
    {
        public class DevQuit : DevInputCommand { }
        public class DevCast : DevInputCommand { }
    }
}
