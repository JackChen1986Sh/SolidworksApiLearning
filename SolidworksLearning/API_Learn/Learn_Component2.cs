using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidworksLearning.API_Learn
{
    public class Learn_Component2
    {
        public static void SetComponentsStatus(Component2 SwComp)
        {
            SwComp.SetSuppression2((int)swComponentSuppressionState_e.swComponentSuppressed);
            System.Windows.MessageBox.Show("部件" + SwComp.Name2 + ":被压缩");
            SwComp.SetSuppression2((int)swComponentSuppressionState_e.swComponentResolved);
            System.Windows.MessageBox.Show("部件" + SwComp.Name2 + ":被解压");
            SwComp.SetSuppression2((int)swComponentSuppressionState_e.swComponentFullyLightweight);
            System.Windows.MessageBox.Show("部件" + SwComp.Name2 + ":被轻化");
            SwComp.SetSuppression2((int)swComponentSuppressionState_e.swComponentResolved);//还原解压
        }
        public static void SetCompBomInclude(Component2 SwComp)
        {
            SwComp.ExcludeFromBOM = true;
            System.Windows.MessageBox.Show("部件" + SwComp.Name2 + ":设置为不包含在明细表中");
            SwComp.ExcludeFromBOM = false;
            System.Windows.MessageBox.Show("部件" + SwComp.Name2 + ":设置包含在明细表中");
        }
        public static void SetCompConfig(ModelDoc2 AssemDoc, Component2 SwComp)
        {
            SwComp.ReferencedConfiguration = "配置2";
            AssemDoc.EditRebuild3();
            System.Windows.MessageBox.Show("部件" + SwComp.Name2 + ":使用了配置2");
            SwComp.ReferencedConfiguration = "Default";
            AssemDoc.EditRebuild3();
            System.Windows.MessageBox.Show("部件" + SwComp.Name2 + ":使用了Default配置");
        }


    }
}
