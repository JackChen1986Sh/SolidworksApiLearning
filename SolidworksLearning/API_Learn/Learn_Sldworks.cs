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

        public static ModelDoc2 OpenDoc(SldWorks iswApp,string DocPath,bool ShowMsg)
        {
            int err = -1;
            int warn = -1;
            ModelDoc2 OpenDoc = iswApp.OpenDoc6(DocPath, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_AutoMissingConfig, "圆壳", ref err, ref warn);
            if (OpenDoc != null)
            {
                if (ShowMsg)
                {
                    MessageBox.Show("零件打开成功:" + OpenDoc.GetTitle() + "\r\n");
                }
            }
            else
            {
                MessageBox.Show("零件打开失败！" + "\r\n");
            }
            return OpenDoc;
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
        public static void ActivateDoc(SldWorks iswApp)
        {
            int err = -1;
            int warn = -1;
            iswApp.OpenDoc6(AppDomain.CurrentDomain.BaseDirectory + @"RectanglePlug\PlugTopBox.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_AutoMissingConfig, "圆壳", ref err, ref warn);
            iswApp.OpenDoc6(AppDomain.CurrentDomain.BaseDirectory + @"RectanglePlug\PlugWire.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_AutoMissingConfig, "", ref err, ref warn);
            ModelDoc2 Doc = iswApp.ActiveDoc;
            MessageBox.Show("当前激活文档:" + Doc.GetTitle());
            Doc = iswApp.ActivateDoc3("PlugTopBox.SLDPRT", true, (int)swRebuildOnActivation_e.swRebuildActiveDoc, ref err);
            MessageBox.Show("文档:" + Doc.GetTitle() + "被激活");
            Doc = iswApp.ActiveDoc;
            MessageBox.Show("当前激活文档:" + Doc.GetTitle());
        }
        public static void LoadThirdPartFile(SldWorks iswApp)
        {
            int err = -1;

            //启用3D Interconnect
            string FileName = AppDomain.CurrentDomain.BaseDirectory + @"ThirdPart\PlugBottomBox.IGS";
            ImportIgesData importData = default(ImportIgesData);
            importData = (ImportIgesData)iswApp.GetImportFileData(FileName);
            if ((importData != null))//指定参数加载
            {
                importData.IncludeSurfaces = true;
                importData.IncludeCurves = true;
                importData.CurvesAsSketches = true;
                importData.ProcessByLevel = false;
            }
            iswApp.LoadFile4(FileName, "", importData, ref err);

            //启用3D Interconnect
            FileName = AppDomain.CurrentDomain.BaseDirectory + @"ThirdPart\PowerStrip.IGS";
            importData = default(ImportIgesData);
            importData = (ImportIgesData)iswApp.GetImportFileData(FileName);
            if ((importData != null))//指定参数加载
            {
                importData.IncludeSurfaces = true;
                importData.IncludeCurves = true;
                importData.CurvesAsSketches = true;
                importData.ProcessByLevel = false;
            }
            iswApp.LoadFile4(FileName, "", importData, ref err);

            //不启用3D Interconnect
            FileName = AppDomain.CurrentDomain.BaseDirectory + @"ThirdPart\PlugBottomBoxNon.IGS";
            iswApp.LoadFile4(FileName, "r", null, ref err);

        }


        public static void CloseDoc(SldWorks iswApp)
        {
            int err = -1;
            int warn = -1;
            iswApp.OpenDoc6(AppDomain.CurrentDomain.BaseDirectory + @"RectanglePlug\PlugTopBox.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_AutoMissingConfig, "圆壳", ref err, ref warn);
            iswApp.OpenDoc6(AppDomain.CurrentDomain.BaseDirectory + @"RectanglePlug\PlugBottomBox.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_AutoMissingConfig, "", ref err, ref warn);
            iswApp.OpenDoc6(AppDomain.CurrentDomain.BaseDirectory + @"RectanglePlug\PlugWire.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_AutoMissingConfig, "", ref err, ref warn);
            MessageBox.Show("三个文档已打开，点击后，将关闭PlugTopBox.SLDPRT");
            iswApp.CloseDoc(AppDomain.CurrentDomain.BaseDirectory + @"RectanglePlug\PlugTopBox.SLDPRT");
            MessageBox.Show("关闭成功，再次点击将关闭所有文档");
            iswApp.CloseAllDocuments(true);
            MessageBox.Show("所有文档已关闭");
        }

        public static void SystamSet(SldWorks iswApp)
        {
            iswApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swInputDimValOnCreate, true);
        }
    }
}
