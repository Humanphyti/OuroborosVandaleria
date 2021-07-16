using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Engine.Input
{
    public class MenuInputCommand : BaseInputCommand
    {
        public class ItemSelect : MenuInputCommand { }
        public class NavgiateLeft : MenuInputCommand { }
        public class NavigateRight : MenuInputCommand { }
        public class NavigateUp : MenuInputCommand { }
        public class NavigateDown : MenuInputCommand { }
        public class UniversalBack : MenuInputCommand { }
        public class BankLeft : MenuInputCommand { }
        public class BankRight : MenuInputCommand { }
        public class ScreenLeft : MenuInputCommand { }
        public class ScreenRight : MenuInputCommand { }
    }
}
