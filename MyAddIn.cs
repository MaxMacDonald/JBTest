using CodeStack.SwEx.AddIn;
using CodeStack.SwEx.AddIn.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld1
{
    [ComVisible(true), Guid("31E60808-5D81-40E5-BD33-7F103FB51F4A")]
    [AutoRegister("Geom primatives", "Hello World")]
    public class MyAddIn : SwAddInEx
    {
        private enum Commands_e
        {
            HelloWorld
        }

        public override bool OnConnect()
        {
            AddCommandGroup<Commands_e>(OnButtonClick);
            return true;
        }

        private void OnButtonClick(Commands_e cmd)
        {
            switch (cmd)
            {
                case Commands_e.HelloWorld:
                    App.SendMsgToUser("Hello World!");
                    break;
            }
        }
    }
}