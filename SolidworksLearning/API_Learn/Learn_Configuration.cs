using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;


namespace SolidworksLearning.API_Learn
{
    public class Learn_Configuration
    {
        public static void CreateConfig(ModelDoc2 Doc)
        {
            ConfigurationManager SwConfigMrg = Doc.ConfigurationManager;
            Configuration SwConfig2 = SwConfigMrg.AddConfiguration2("形状2", "配置2", "11", 1, "", "描述2", true);
            Configuration SwConfig3 = SwConfigMrg.AddConfiguration2("形状3", "配置3", "33", 5, "", "描述3", true);
            Configuration SwConfig4 = SwConfigMrg.AddConfiguration2("形状4", "配置4", "44", 4, "", "描述4", true);
            Configuration SwConfig5 = SwConfigMrg.AddConfiguration2("形状5", "配置5", "55", 1, "Default", "描述5", true);
        }
        public static void GetConfig(ModelDoc2 Doc)
        {
            Configuration SwConfig2 = Doc.GetConfigurationByName("形状2");
            if (SwConfig2 != null)
            {
                string Comment = SwConfig2.Comment;
                string AlternateName = SwConfig2.AlternateName;
                Doc.ShowConfiguration2("形状2");
                System.Windows.MessageBox.Show("配置[形状2]被激活\r\n"+Comment + "\r\n" + AlternateName);
            }
            else
            {
                System.Windows.MessageBox.Show("未找到配置2");
            }
        }
        public static void DelConfig(ModelDoc2 Doc)
        {
            //配置未被激活才能被删除
            Doc.DeleteConfiguration2("形状2");
            Doc.DeleteConfiguration2("形状3");
            Doc.DeleteConfiguration2("形状4");
            Doc.DeleteConfiguration2("形状5");
        }


    }
}
