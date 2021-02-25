using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidworksLearning.API_Learn
{
    class Learn_Dimension
    {
        public static void GetDim(ModelDoc2 Doc,string DimName)
        {
            Dimension SwDim = Doc.Parameter(DimName);
            StringBuilder sb = new StringBuilder("");
            sb.Append("尺寸名:"+ SwDim.Name+"\r\n");
            sb.Append("完整尺寸名:" + SwDim.FullName + "\r\n");
            sb.Append("选择名:" + SwDim.GetNameForSelection() + "\r\n");
            double[] aa = SwDim.GetValue3((int)swInConfigurationOpts_e.swSpecifyConfiguration,new string[] { "Default" ,"cfg2"});
            sb.Append("Default配置-尺寸值:" + aa[0] + "\r\n");
            sb.Append("cfg2配置-尺寸值:" + aa[1] + "\r\n");    
            System.Windows.MessageBox.Show(sb.ToString().Trim());
        }
        public static void SetDim(ModelDoc2 Doc, string DimName,Dictionary<string,double> Vals)
        {
            Dimension SwDim = Doc.Parameter(DimName);
            foreach (string cfg in Vals.Keys)
            {
                SwDim.SetValue3(Vals[cfg], (int)swSetValueInConfiguration_e.swSetValue_InSpecificConfigurations, new string[] { cfg });
            }
            Doc.EditRebuild3();
        }
    }
}
