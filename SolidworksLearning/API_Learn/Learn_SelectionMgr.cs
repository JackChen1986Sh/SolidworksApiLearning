using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidworksLearning.API_Learn
{
    public class Learn_SelectionMgr
    {
        public static void GetFace(ModelDoc2 Doc)
        {
            ModelDocExtension DocEx = Doc.Extension;
            SelectionMgr SwSelMrg = Doc.SelectionManager;
            DocEx.SelectByID2("", "FACE", -100 / 1000.0, 60 / 1000.0, 15 / 1000.0, false, -1, null, 0);
            System.Windows.MessageBox.Show("模拟选中面");

            string selcount = SwSelMrg.GetSelectedObjectCount2(-1).ToString();
            swSelectType_e  seltype = (swSelectType_e)SwSelMrg.GetSelectedObjectType3(1,-1);
            if (seltype == swSelectType_e.swSelFACES)
            {
                Face2 SwFace = SwSelMrg.GetSelectedObject6(1,-1);
                System.Windows.MessageBox.Show("选中数:"+ selcount + "\r\n选中类型:"+ seltype .ToString()+ "\r\n选中面面积:" + SwFace.GetArea().ToString());
            }
        }
        public static void GetEdge(ModelDoc2 Doc)
        {
            ModelDocExtension DocEx = Doc.Extension;
            SelectionMgr SwSelMrg = Doc.SelectionManager;
            DocEx.SelectByID2("", "EDGE", 0 / 1000.0, 30 / 1000.0, 75 / 1000.0, false, -1, null, 0);
            System.Windows.MessageBox.Show("模拟选中边线");

            string selcount = SwSelMrg.GetSelectedObjectCount2(-1).ToString();
            swSelectType_e seltype = (swSelectType_e)SwSelMrg.GetSelectedObjectType3(1, -1);
            if (seltype == swSelectType_e.swSelEDGES)
            {
                Edge SwEdge = SwSelMrg.GetSelectedObject6(1, -1);
                SwEdge.Display(1, 1, 0, 0, true);//true变色开，false关闭变色
                System.Windows.MessageBox.Show("选中数:" + selcount + "\r\n选中类型:" + seltype.ToString() + "\r\n选中边已变色");
            }

        }
        public static void GetSelectList(ModelDoc2 Doc)
        {
            ModelDocExtension DocEx = Doc.Extension;
            SelectionMgr SwSelMrg = Doc.SelectionManager;
            DocEx.SelectByID2("", "FACE", -100 / 1000.0, 60 / 1000.0, 15 / 1000.0, false, -1, null, 0);
            DocEx.SelectByID2("", "EDGE", 0 / 1000.0, 30 / 1000.0, 75 / 1000.0, true, -1, null, 0);
            System.Windows.MessageBox.Show("模拟选中多个元素完成");

            StringBuilder Sb = new StringBuilder("选择集合信息:\r\n");
            int selcount = SwSelMrg.GetSelectedObjectCount2(-1);
            Sb.Append("选择总数:"+ selcount .ToString()+ "\r\n");
            Sb.Append("-----------------\r\n");
            for (int i = 1; i <= selcount; i++)
            {
                Sb.Append("index参数为"+i.ToString()+"的对象\r\n");
                swSelectType_e seltype = (swSelectType_e)SwSelMrg.GetSelectedObjectType3(i, -1);
                Sb.Append("类型:"+ seltype.ToString().Trim()+"\r\n");
                Sb.Append("-----------------\r\n");
            }
            System.Windows.MessageBox.Show(Sb.ToString());
        }



    }
}
