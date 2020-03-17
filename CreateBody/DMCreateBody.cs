using CodeStack.SwEx.PMPage.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.swconst;
using System.ComponentModel;

namespace HelloWorld1
{
    public class DMCreateBody
    {
        [ControlAttribution(swControlBitmapLabelType_e.swBitmapLabel_LinearDistance)]
        [Description("Size")]
        [NumberBoxOptions(units:swNumberboxUnitType_e.swNumberBox_Length, minimum: 0.0001, maximum:1, inclusive: true, increment: 0.01, fastIncrement: 0.001, slowIncrement: 0.001)]
        public double X { get; set; }


        [ControlAttribution(swControlBitmapLabelType_e.swBitmapLabel_LinearDistance)]
        [Description("Size")]
        [NumberBoxOptions(units: swNumberboxUnitType_e.swNumberBox_Length, minimum: 0.0001, maximum: 1, inclusive: true, increment: 0.01, fastIncrement: 0.001, slowIncrement: 0.001)]
        public double Y { get; set; }


        [ControlAttribution(swControlBitmapLabelType_e.swBitmapLabel_LinearDistance)]
        [Description("Size")]
        [NumberBoxOptions(units: swNumberboxUnitType_e.swNumberBox_Length, minimum: 0.0001, maximum: 1, inclusive: true, increment: 0.01, fastIncrement: 0.001, slowIncrement: 0.001)]
        public double Z { get; set; }
        

        [Description("Helix")]
        public bool Helix { get; set; }


    }

}
