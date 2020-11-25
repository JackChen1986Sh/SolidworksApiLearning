using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidworksLearning.API_Learn
{
    public class Learn_CustomPropertyManager
    {
        public static void WriteCusp(ModelDoc2 Doc)
        {
            CustomPropertyManager SwCusp = Doc.Extension.CustomPropertyManager[""];

            string PartName = "长方体 \"D2@草图2@Solidworks属性学习.SLDPRT\"X\"D1@草图2@Solidworks属性学习.SLDPRT\"X\"D1@凸台-拉伸1@Solidworks属性学习.SLDPRT\"";
            SwCusp.Add3("零件名", (int)swCustomInfoType_e.swCustomInfoText, PartName, (int)swCustomPropertyAddOption_e.swCustomPropertyReplaceValue);
            SwCusp.Add3("代号", (int)swCustomInfoType_e.swCustomInfoText, "001", (int)swCustomPropertyAddOption_e.swCustomPropertyReplaceValue);
            SwCusp.Add3("重量", (int)swCustomInfoType_e.swCustomInfoText, "\"SW-质量@Solidworks属性学习.SLDPRT\"", (int)swCustomPropertyAddOption_e.swCustomPropertyReplaceValue);
            SwCusp.Add3("材料", (int)swCustomInfoType_e.swCustomInfoText, "\"SW-材质@Solidworks属性学习.SLDPRT\"", (int)swCustomPropertyAddOption_e.swCustomPropertyReplaceValue);
            System.Windows.MessageBox.Show("属性写入成功!");
        }
        public static void ReadCusp(ModelDoc2 Doc)
        {
            StringBuilder Sb = new StringBuilder("");
            CustomPropertyManager SwCusp = Doc.Extension.CustomPropertyManager[""];
            string outv = "";
            string outr = "";
            bool outresult = false;

            SwCusp.Get5("零件名", true, out outv, out outr, out outresult);
            Sb.Append("[零件名]:\r\n表达式:"+ outv+"\r\n评估值:"+ outr);
            Sb.Append("\r\n");
            SwCusp.Get5("代号", true, out outv, out outr, out outresult);
            Sb.Append("[代号]:\r\n表达式:" + outv + "\r\n评估值:" + outr);
            Sb.Append("\r\n");
            SwCusp.Get5("材料", true, out outv, out outr, out outresult);
            Sb.Append("[材料]:\r\n表达式:" + outv + "\r\n评估值:" + outr);
            System.Windows.MessageBox.Show(Sb.ToString().Trim());
        }



    }
}
