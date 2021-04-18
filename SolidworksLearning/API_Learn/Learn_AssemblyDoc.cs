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
       
        public static void AddMate(SldWorks swApp, ModelDoc2 Doc, string newpartpath)
        {
            #region 添加部件
            swApp.OpenDoc(newpartpath, 1);
            ((AssemblyDoc)Doc).AddComponent5(newpartpath, 0, "", false, "", 0, 0.3, 0);
            swApp.CloseDoc(newpartpath);
            #endregion

            Component2 BaseComp = ((AssemblyDoc)Doc).GetComponentByName("底座-1");
            Component2 RoateComp = ((AssemblyDoc)Doc).GetComponentByName("转轴-1");

            int err = 0;
            #region 轴装配
            Feature BaseAxi = BaseComp.FeatureByName("基准轴1");
            Feature RoateAxi = RoateComp.FeatureByName("转轴中心轴");
            BaseAxi.Select(false);
            RoateAxi.Select(true);
            ((AssemblyDoc)Doc).AddMate5((int)swMateType_e.swMateCOINCIDENT, (int)swMateAlign_e.swMateAlignALIGNED,false,0,0,0,0,0,0,0,0,false,false,0,out err);
            #endregion

            #region 底面装配距离
            Feature BaseBp = BaseComp.FeatureByName("Top");
            Feature RoateBp = RoateComp.FeatureByName("Top");
            BaseBp.Select(false);
            RoateBp.Select(true);
            ((AssemblyDoc)Doc).AddMate5((int)swMateType_e.swMateDISTANCE, (int)swMateAlign_e.swMateAlignALIGNED, false, 10/1000.0, 10 / 1000.0, 10 / 1000.0, 0, 0, 0, 0, 0, false, false, 0, out err);
            #endregion

            #region 方位装配
            Feature BaseOir = BaseComp.FeatureByName("Right");
            Feature RoateOir = RoateComp.FeatureByName("Right");
            BaseOir.Select(false);
            RoateOir.Select(true);
            ((AssemblyDoc)Doc).AddMate5((int)swMateType_e.swMateANGLE, (int)swMateAlign_e.swMateAlignALIGNED, false,0, 0, 0, 0, 0, (30/180.0)*Math.PI, (30 / 180.0) * Math.PI, (30 / 180.0) * Math.PI, false, false, 0, out err);
            #endregion

            Doc.EditRebuild3();
        }





    }
}
