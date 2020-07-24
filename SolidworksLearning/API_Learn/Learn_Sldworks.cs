using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Diagnostics;
using System.Windows;

namespace SolidworksLearning.API_Learn
{
    public class Learn_Sldworks
    {

        public static SldWorks NewSolidworksApp()
        {
            SldWorks swApp;
            swApp = new SldWorks();
            //swApp.UserControl =true;
            swApp.Visible = true;
            return swApp;
        }
        public static SldWorks GetSolidworksApp()
        {
            SldWorks swApp;
            bool ExistSwApp = false;
            foreach (Process thisproc in Process.GetProcessesByName("SLDWORKS"))
            {
                ExistSwApp = true;
                break;
            }
            if (ExistSwApp)
            {
                Type swtype = Type.GetTypeFromProgID("SldWorks.Application");
                swApp = (SldWorks)Activator.CreateInstance(swtype);
                return swApp;
            }
            else
            {
                return null;
            }
        }

        public static void NewDoc(SldWorks iswApp)
        {
            ModelDoc2 PartDoc = iswApp.NewDocument(AppDomain.CurrentDomain.BaseDirectory + @"SwFile\PartTemplate.PRTDOT", (int)swDwgPaperSizes_e.swDwgPaperA0size, 10, 10);
            ModelDoc2 AssemDoc = iswApp.NewDocument(AppDomain.CurrentDomain.BaseDirectory + @"SwFile\AssemTemplate.ASMDOT", (int)swDwgPaperSizes_e.swDwgPaperA0size, 10, 10);
            ModelDoc2 DrawDoc = iswApp.NewDocument(AppDomain.CurrentDomain.BaseDirectory + @"SwFile\DrawingTemplate.DRWDOT", (int)swDwgPaperSizes_e.swDwgPaperA0size, 10, 10);
            StringBuilder Sb = new StringBuilder();
            if (PartDoc != null)
            {
                Sb.Append("零件新建成功" + PartDoc.GetTitle() + "\r\n");
            }
            else
            {
                Sb.Append("零件新建失败！" + "\r\n");
            }
            if (AssemDoc != null)
            {
                Sb.Append("装配体新建成功" + AssemDoc.GetTitle() + "\r\n");
            }
            else
            {
                Sb.Append("装配体新建失败！" + "\r\n");
            }
            if (DrawDoc != null)
            {
                Sb.Append("图纸新建成功" + DrawDoc.GetTitle() + "\r\n");
            }
            else
            {
                Sb.Append("图纸新建失败！" + "\r\n");
            }
            MessageBox.Show(Sb.ToString().Trim());
        }

        public static void OpenDoc(SldWorks iswApp)
        {
            int err = -1;
            int warn = -1;
            ModelDoc2 OpenDoc = iswApp.OpenDoc6(AppDomain.CurrentDomain.BaseDirectory + @"RectanglePlug\PlugTopBox.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_AutoMissingConfig, "圆壳", ref err, ref warn);
            if (OpenDoc != null)
            {
                MessageBox.Show("零件打开成功:" + OpenDoc.GetTitle() + "\r\n");
            }
            else
            {
                MessageBox.Show("零件打开失败！" + "\r\n");
            }
        }

        public static void GetAllOpenedDoc(SldWorks iswApp)
        {
            object[] ObjDocs = iswApp.GetDocuments();
            if (ObjDocs != null)
            {
                StringBuilder Sb = new StringBuilder();
                foreach (object x in ObjDocs)
                {
                    if (x is ModelDoc2)
                    {
                        Sb.Append(((ModelDoc2)x).GetTitle() + "\r\n");
                    }
                }
                MessageBox.Show("打开的文档:\r\n" + Sb.ToString().Trim());
            }
        }


     }
}
