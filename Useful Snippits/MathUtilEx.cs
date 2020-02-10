using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld1.Useful_Snippits
{

    public static class MathUtilEx
    {
        public static MathTransform
           CreateTransformEx(this IMathUtility mathUtility,
                             double Xx = 0d,    // a
                             double Xy = 0d,    // b
                             double Xz = 0d,    // c
                             double Yx = 0d,    // d
                             double Yy = 0d,    // e
                             double Yz = 0d,    // f
                             double Zx = 0d,    // g
                             double Zy = 0d,    // h
                             double Zz = 0d,    // i
                             double Tx = 0d,    // j
                             double Ty = 0d,    // k
                             double Tz = 0d,    // l
                             double scale = 1d) // m

        {
            //https://help.solidworks.com/2018/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.imathtransform.html

            if (mathUtility.CreateTransform(new double[] { Xx, Xy, Xz, Yx, Yy, Yz, Zx, Zy, Zz, Tx, Ty, Tz, scale, 0d, 0d, 0d }) is MathTransform transform)
            {
                return transform;
            }
            return null;
        }
    }

}
