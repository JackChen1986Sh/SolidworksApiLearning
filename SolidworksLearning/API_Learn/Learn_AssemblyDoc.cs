using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidworksLearning.API_Learn
{
    public class Learn_AssemblyDoc
    {
        public static void GetAssemDoc(ModelDoc2 Doc)
        {
        
        
        }

        public static void GetChildrenComp(ModelDoc2 Doc)
        {
            if (Doc.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY)
            {
                AssemblyDoc Assem = (AssemblyDoc)Doc;

                #region 顶底层零部件
                StringBuilder topsb = new StringBuilder("顶层部件:\r\n");
                object[] Comps = Assem.GetComponents(true);
                foreach (object cp in Comps)
                {
                    topsb.Append(((Component2)cp).Name2+"\r\n");
                }
                #endregion

                #region 所有零部件
                StringBuilder allsb = new StringBuilder("所有部件:\r\n");
                Comps = Assem.GetComponents(false);
                foreach (object cp in Comps)
                {
                    allsb.Append(((Component2)cp).Name2 + "\r\n");
                }
                #endregion

                System.Windows.MessageBox.Show(topsb+"\r\n" + allsb);
            }
        }

        public static void InsertPart(SldWorks swApp ,ModelDoc2 Doc,string newpartpath)
        {
            swApp.OpenDoc(newpartpath,1);
            ((AssemblyDoc)Doc).AddComponent5(newpartpath,0,"",false,"",0,0.3,0);
            ((AssemblyDoc)Doc).AddComponent5(newpartpath, 0, "", true, "实心", 0.5, 0.3, 0);
            ((AssemblyDoc)Doc).AddComponent5(newpartpath, 0, "", true, "挖孔", 1, 0.3, 0);
            swApp.CloseDoc(newpartpath);
        }


    }
}
