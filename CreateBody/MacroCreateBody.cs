using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStack.SwEx.AddIn;
using CodeStack.SwEx.AddIn.Attributes;
using CodeStack.SwEx.Common.Attributes;
using CodeStack.SwEx.PMPage;

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

        public bool CreateBodies(ISldWorks app, bool temp)
        {
            var resBodies = new List<IBody2>();
            var modeler = app.GetModeler() as Modeler;
            var mathUtil = app.IGetMathUtility();
            double[] vectorN = new double[] { 1, 0, 0 };
            double[] pointN = new double[] { 0, 0, 0 };
            if (helix == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    double Xstart = sizeX * i;
                    resBodies.Add(modeler.CreateBodyFromBox3(new double[] { Xstart, 0d, 0d, 1d, 0d, 0d, sizeX, sizeY, sizeZ }));


                    double Rotation = 36 * (i + 1);
                    var vector = mathUtil.CreateVector(vectorN);
                    var point = mathUtil.CreatePoint(pointN);
                    MathTransform rotation = (MathTransform)mathUtil.CreateTransformRotateAxis(point, vector, Rotation);
                    resBodies[i].ApplyTransform(rotation);

                }
                if (temp == true)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        resBodies[i].Display3(app.IActiveDoc2, 100, 1);
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        resBodies[i].CreateBaseFeature(resBodies[i]);
                    }
                }
            }
            else
            {
                resBodies.Add(modeler.CreateBodyFromBox3(new double[] { 0d, 0d, 0d, 1d, 0d, 0d, sizeX, sizeY, sizeZ }));
                if (temp == true)
                {
                    resBodies[0].Display3(app.IActiveDoc2, 100, 1);
                }
                else
                {
                    resBodies[0].CreateBaseFeature(resBodies[0]);
                }

            }
            return true;

        }


        
    }
}
