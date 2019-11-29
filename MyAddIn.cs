using CodeStack.SwEx.AddIn;
using CodeStack.SwEx.AddIn.Attributes;
using CodeStack.SwEx.PMPage;
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

        PropertyManagerPageEx<PropertyPageHandeler, DMHelloWorld> m_HelloWorldPage;

        DMHelloWorld m_HelloWorldData;


        public override bool OnConnect()
        {
            AddCommandGroup<Commands_e>(OnButtonClick);
            m_HelloWorldData = new DMHelloWorld();
            m_HelloWorldData.message = 4;
            m_HelloWorldPage = new PropertyManagerPageEx<PropertyPageHandeler, DMHelloWorld>(App);
            m_HelloWorldPage.Handler.Closed += OnHelloWorldClosed;
            return true;
        }

        private void OnHelloWorldClosed(SolidWorks.Interop.swconst.swPropertyManagerPageCloseReasons_e reason)
        {
            App.SendMsgToUser($"{m_HelloWorldData.message}");
        }

        private void OnButtonClick(Commands_e cmd)
        {
            switch (cmd)
            {
                case Commands_e.HelloWorld:
                    m_HelloWorldPage.Show(m_HelloWorldData);
                    //App.SendMsgToUser("Hello Worlds!");
                    break;
            }
        }
    }
}