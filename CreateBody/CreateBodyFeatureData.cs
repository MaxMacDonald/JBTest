using CodeStack.SwEx.MacroFeature.Attributes;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld1.CreateBody
{
    public class CreateBodyFeatureData
    {
        [ParameterDimension(swDimensionType_e.swLinearDimension)]
        public double X { get; set; }

        public CreateBodyFeatureData() { }

        public CreateBodyFeatureData(CreateBodyPageData pageData)
        {
            X = pageData.X;
        }
        
    }
}
