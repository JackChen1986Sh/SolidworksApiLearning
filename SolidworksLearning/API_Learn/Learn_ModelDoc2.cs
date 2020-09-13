using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidworksLearning.API_Learn
{
    public class Learn_ModelDoc2
    {
        public static void GetDocObject(SldWorks iswApp)
        {
            StringBuilder sb = new StringBuilder("");
            ModelDoc2 SwDoc = iswApp.ActiveDoc;//获得当前激活的文档
            sb.Append("文档:"+ SwDoc.GetTitle()+"\r\n");
            int DocType = SwDoc.GetType();//获得激活的文档类型
            if (DocType == (int)swDocumentTypes_e.swDocPART)//若类型是零件
            {
                PartDoc SwPart = (PartDoc)SwDoc;
                sb.Append("文档类型:零部件\r\n");
            }
            else if (DocType == (int)swDocumentTypes_e.swDocASSEMBLY)//若类型是装配体
            {
                AssemblyDoc SwAssem = (AssemblyDoc)SwDoc;
                sb.Append("文档类型:装配体\r\n");
            }
            else if (DocType == (int)swDocumentTypes_e.swDocDRAWING)//若类型是工程图
            {
                DrawingDoc SwAssem = (DrawingDoc)SwDoc;
                sb.Append("文档类型:工程图\r\n");
            }
            ModelDocExtension SwDocEx = SwDoc.Extension;//获得扩展文档对象
            if (SwDocEx!=null)
            {
                sb.Append("扩展文档:已获得");
            }
            MessageBox.Show(sb.ToString().Trim());
        }

    }
}
