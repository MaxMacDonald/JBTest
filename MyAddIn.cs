﻿using CodeStack.SwEx.AddIn;
using CodeStack.SwEx.AddIn.Attributes;
using CodeStack.SwEx.PMPage;
using SolidWorks.Interop.swconst;
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
            HelloWorld,
            CreateBody
        }

        PropertyManagerPageEx<PropertyPageHandeler, DMHelloWorld> m_HelloWorldPage;
        PropertyManagerPageEx<PropertyPageHandeler, DMCreateBody> m_CreateBodyPage;

        DMHelloWorld m_HelloWorldData;
        DMCreateBody m_CreateBodyData;


        public override bool OnConnect()
        {
            AddCommandGroup<Commands_e>(OnButtonClick);
            m_HelloWorldData = new DMHelloWorld();
            m_HelloWorldData.message = "Hi";
            m_HelloWorldPage = new PropertyManagerPageEx<PropertyPageHandeler, DMHelloWorld>(App);
            m_HelloWorldPage.Handler.Closed += OnHelloWorldClosed;

            m_CreateBodyData = new DMCreateBody();
            m_CreateBodyPage = new PropertyManagerPageEx<PropertyPageHandeler, DMCreateBody>(App);
            m_CreateBodyPage.Handler.Closed += OnCreateBodyClosed;
            return true;
        }

        private void OnCreateBodyClosed(swPropertyManagerPageCloseReasons_e reason)
        {
            
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

                case Commands_e.CreateBody:
                    m_CreateBodyPage.Show(m_CreateBodyData);
  
                    break;
            }
        }
        
    }
}


// --------------------------------The Code below is from the VBA macro written in Solidworks---------------------------------------------

//Dim swApp As SldWorks.SldWorks
//Dim swModel As SldWorks.ModelDoc2
//Dim swPart As SldWorks.PartDoc

//'Plan

//'Create circle sketch
//'Extrude
//'Select a face
//'Use cut to form a series of indents at varing levels


//Sub main()

//Set swApp = Application.SldWorks
//Set swModel = swApp.NewDocument("C:\Share\SW2018\LIBRARY\Document Templates\JB Empty Part.prtdot", 0, 0#, 0#)
//Set swPart = swModel
//Dim bs As Boolean
//Dim swSelMgr As SldWorks.SelectionMgr
//Set swSelMgr = swModel.SelectionManager
//Dim dp As New DefaultPlanes
//Dim swFeat As Feature
//Dim swFace As SldWorks.Face2
//Dim swEnt As SldWorks.Entity





//Set dp.Model = swModel
//bs = dp.Front.Select2(False, 0)

//With swModel.SketchManager
//    .InsertSketch False
//    Call.CreateCircle(0#, 0#, 0#, 0.1, 0#, 0#)
//    .InsertSketch True
//End With
//Dim swFeature As SldWorks.Feature


//Set swFeature = swModel.FeatureManager.FeatureExtrusion3(Sd:= True, _
//    Flip:= False, _
//    Dir:= False, _
//    T1:= swEndCondBlind, _
//    T2:= 0, _
//    D1:= 0.05, _
//    D2:= 0, _
//    Dchk1:= False, _
//    Dchk2:= False, _
//    Ddir1:= 0, _
//    Ddir2:= 0, _
//    Dang1:= 0, _
//    Dang2:= 0, _
//    OffsetReverse1:= 0, _
//    OffsetReverse2:= 0, _
//    TranslateSurface1:= 0, _
//    TranslateSurface2:= 0, _
//    Merge:= False, _
//    UseFeatScope:= False, _
//    UseAutoSelect:= False, _
//    T0:= swStartSketchPlane, _
//    StartOffset:= 0, _
//    FlipStartOffset:= 0)



//Set swFace = swFeature.GetFaces(0)

//Set swEnt = swFace


//Dim swSketch(1 To 4) As SldWorks.Sketch

//Dim i As Long
//For i = 4 To 1 Step - 1
//    Call swEnt.Select4(False, Nothing)
//    With swModel.SketchManager
//        .InsertSketch False
//        Set swSketch(i) = .ActiveSketch
//        Call.CreateCircle(0#, 0#, 0#, (0.02 * i), 0#, 0#)
//        .InsertSketch True
//    End With

//Next i

//For i = 4 To 1 Step - 1
//    Set swFeature = swSketch(i)
//    Call swFeature.Select(False)
//    Call swModel.FeatureManager.FeatureCut4(Sd:= True, _
//        Flip:= True, _
//        Dir:= False, _
//        T1:= swEndCondBlind, T2:= swEndCondBlind, _
//        D1:= 0.01 * i, D2:= 0#, _
//        Dchk1:= False, Dchk2:= False, _
//        Ddir1:= False, Ddir2:= False, _
//        Dang1:= 0#, _
//        Dang2:= 0#, _
//        OffsetReverse1:= False, _
//        OffsetReverse2:= False, _
//        TranslateSurface1:= False, TranslateSurface2:= False, _
//        NormalCut:= False, _
//        UseFeatScope:= False, _
//        UseAutoSelect:= True, _
//        AssemblyFeatureScope:= False, _
//        AutoSelectComponents:= False, _
//        PropagateFeatureToParts:= False, _
//        T0:= swStartSketchPlane, _
//        StartOffset:= 0#, _
//        FlipStartOffset:= Flase, _
//        OptimizeGeometry:= False)


//Next i
