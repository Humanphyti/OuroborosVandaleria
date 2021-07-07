using OuroborosVandaleriaCore.Engine.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Screen.Dev
{
    public class DevInputCommand : BaseInputCommand
    {
        public class DevQuit : DevInputCommand { }
        public class DevPause : DevInputCommand { }
        public class DevCast : DevInputCommand { }
        public class DevMoveUp : DevInputCommand { }
        public class DevMoveDown : DevInputCommand { }
        public class DevMoveLeft : DevInputCommand { }
        public class DevMoveRight : DevInputCommand { }
        public class DevStab : DevInputCommand { }
    }
}
