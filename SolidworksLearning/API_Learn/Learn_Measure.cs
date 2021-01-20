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
            SelectionMgr SwSelMrg = Doc.SelectionManager;
            Measure SwMeasure = DocEx.CreateMeasure();

            DocEx.SelectByID2("", "FACE",-100/1000.0,60/1000.0,15/1000.0,false,-1,null,0);
            DocEx.SelectByID2("", "FACE", 100 / 1000.0, 60 / 1000.0, 15 / 1000.0, true, -1, null, 0);

            Face2 SwFace1 = SwSelMrg.GetSelectedObject6(1, -1);
            Face2 SwFace2 = SwSelMrg.GetSelectedObject6(2, -1);
            Entity[] ents = new Entity[] { (Entity)SwFace1, (Entity)SwFace2 };

            SwMeasure.Calculate(ents);
            System.Windows.MessageBox.Show("中心距:" + (SwMeasure.CenterDistance*1000).ToString().Trim()+"mm");
        }

        public static void MeasureEdge(ModelDoc2 Doc)
        {
            ModelDocExtension DocEx = Doc.Extension;
            SelectionMgr SwSelMrg = Doc.SelectionManager;
            Measure SwMeasure = DocEx.CreateMeasure();

            DocEx.SelectByID2("", "EDGE", 100 / 1000.0, 80 / 1000.0, 15 / 1000.0, false, -1, null, 0);
            DocEx.SelectByID2("", "EDGE", 0 / 1000.0, 30 / 1000.0, 30 / 1000.0, true, -1, null, 0);

            Edge SwEdge1 = SwSelMrg.GetSelectedObject6(1, -1);
            Edge SwEdge2 = SwSelMrg.GetSelectedObject6(2, -1);
            Entity[] ents = new Entity[] { (Entity)SwEdge1, (Entity)SwEdge2 };

            SwMeasure.Calculate(ents);

            StringBuilder sb = new StringBuilder("距离:" + (SwMeasure.Distance * 1000).ToString().Trim() + "mm\r\n");
            sb.Append("X距离:"+ (SwMeasure.DeltaX * 1000).ToString().Trim() + "mm\r\n");
            sb.Append("Y距离:" + (SwMeasure.DeltaY * 1000).ToString().Trim() + "mm\r\n");
            sb.Append("Z距离:" + (SwMeasure.DeltaZ * 1000).ToString().Trim() + "mm\r\n");
            System.Windows.MessageBox.Show(sb.ToString().Trim());

        }

        public static void MeasurePointFace(ModelDoc2 Doc)
        {
            ModelDocExtension DocEx = Doc.Extension;
            SelectionMgr SwSelMrg = Doc.SelectionManager;
            Measure SwMeasure = DocEx.CreateMeasure();

            DocEx.SelectByID2("", "FACE", 0 / 1000.0, 15 / 1000.0, 30 / 1000.0, false, -1, null, 0);
            DocEx.SelectByID2("", "VERTEX", 150 / 1000.0, 30 / 1000.0, 75 / 1000.0, true, -1, null, 0);

            Face2 SwFace = SwSelMrg.GetSelectedObject6(1, -1);
            Vertex SwVertex = SwSelMrg.GetSelectedObject6(2, -1);
            Entity[] ents = new Entity[] { (Entity)SwFace, (Entity)SwVertex };

            SwMeasure.Calculate(ents);

            StringBuilder sb = new StringBuilder("距离:" + (SwMeasure.Distance * 1000).ToString().Trim() + "mm\r\n");
            sb.Append("X距离:" + (SwMeasure.DeltaX * 1000).ToString().Trim() + "mm\r\n");
            sb.Append("Y距离:" + (SwMeasure.DeltaY * 1000).ToString().Trim() + "mm\r\n");
            sb.Append("Z距离:" + (SwMeasure.DeltaZ * 1000).ToString().Trim() + "mm\r\n");
            System.Windows.MessageBox.Show(sb.ToString().Trim());

        }



    }
}
