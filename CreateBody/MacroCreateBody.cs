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
        public double sizeX;
        public double sizeY;
        public double sizeZ;
        public bool helix;
        public MacroCreateBody(DMCreateBody Data){

            sizeX = Data.X;
            sizeY = Data.Y;
            sizeZ = Data.Z;
            helix = Data.Helix;
        }

        public List<IBody2> CreateBodies(ISldWorks app)
        {
            if (helix == true)
            {
                var resBodies = new List<IBody2>();
                var modeler = app.GetModeler() as Modeler;
                for (int i = 0; i < 10; i++)
                {
                    double Xstart = sizeX * i;
                    double Rotation = 36 * i;
                    resBodies.Add(modeler.CreateBodyFromBox3(new double[] { Xstart, 0d, 0d, 1d, 0d, 0d, sizeX, sizeY, sizeZ }));
                    
                }
                return resBodies;
            }
            else
            {
                var resBodies = new List<IBody2>();
                var modeler = app.GetModeler() as Modeler;

                resBodies.Add(modeler.CreateBodyFromBox3(new double[] { 0d, 0d, 0d, 1d, 0d, 0d, sizeX, sizeY, sizeZ }));
                return resBodies;
            }
            
        }
        

        
    }
}
