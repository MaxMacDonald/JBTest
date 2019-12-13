using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld1.CreateBody
{
    class MacroCreateBody
    {
        public MacroCreateBody(){}

        List<IBody2> CreateBodies(ISldWorks app)
        {
            var resBodies = new List<IBody2>();
            var modeler = app.GetModeler() as Modeler;

            resBodies.Add(modeler.CreateBodyFromBox3(new double[] { 0, 0, 0, 0, 0, 0, 0.1, 0.1, 0.1 }));
            return resBodies;
        }
        

        
    }
}
