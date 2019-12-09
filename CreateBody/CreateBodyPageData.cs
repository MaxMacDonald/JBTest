using CodeStack.SwEx.Common.Attributes;
using CodeStack.SwEx.PMPage.Attributes;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld1.CreateBody
{
    [PageOptions(swPropertyManagerPageOptions_e.swPropertyManagerOptions_OkayButton
            | swPropertyManagerPageOptions_e.swPropertyManagerOptions_CancelButton
            | swPropertyManagerPageOptions_e.swPropertyManagerOptions_CanEscapeCancel)]
    [Title(typeof(Resource1), nameof(Resource1.CreateBodyTitle))]

    public class CreateBodyPageData
    {
  
        [Description("Size")]
        [ControlAttribution(swControlBitmapLabelType_e.swBitmapLabel_LinearDistance)]
        [NumberBoxOptions(units: swNumberboxUnitType_e.swNumberBox_Length, minimum: 0.001, maximum: 1.0, inclusive:true, increment: 0.01, fastIncrement: 0.1, slowIncrement: 0.1)]

        public double X { get; set; } = 0.01;

        public CreateBodyPageData()
        { }

        public CreateBodyPageData(CreateBodyFeatureData featureData)
        {
            X = featureData.X;
        }

    }
}
