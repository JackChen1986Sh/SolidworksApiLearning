using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;


namespace SolidworksLearning.API_Learn
{
    public class Learn_Measure
    {

        public static void MeasureFace(ModelDoc2 Doc)
        {
            ModelDocExtension DocEx = Doc.Extension;
            Measure SwMeasure = DocEx.CreateMeasure();

            DocEx.SelectByID2("", "FACE",-100/1000.0,60/1000.0,15/1000.0,false,-1,null,0);
            DocEx.SelectByID2("", "FACE", 100 / 1000.0, 60 / 1000.0, 15 / 1000.0, true, -1, null, 0);

            //SwMeasure.Calculate();

        }

        public static void MeasureEdge(ModelDoc2 Doc)
        {


        }

        public static void MeasurePointFace(ModelDoc2 Doc)
        {


        }



    }
}
