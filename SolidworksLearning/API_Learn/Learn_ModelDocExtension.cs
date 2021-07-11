using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;




namespace SolidworksLearning.API_Learn
{
    public class Learn_ModelDocExtension
    {
        public static void GetDocReference(ModelDoc2 AssemDoc)
        {
            object[] ObjFiles1 = AssemDoc.GetDependencies2(true,false,true);
            StringBuilder Sb = new StringBuilder("ModelDoc::GetDependencies2方法:\r\n");
            foreach (object of in ObjFiles1)
            {
                Sb.Append(of.ToString().Trim() + "\r\n");
            }
            System.Windows.MessageBox.Show(Sb.ToString().Trim());


            ModelDocExtension AssemDocEx = AssemDoc.Extension;
            object[] ObjFiles2 = AssemDocEx.GetDependencies(true, false, true, true, true);
            Sb = new StringBuilder("ModelDocExtension::GetDependencies方法:\r\n");
            foreach (object of in ObjFiles2)
            {
                Sb.Append(of.ToString().Trim() + "\r\n");
            }
            System.Windows.MessageBox.Show(Sb.ToString().Trim());

        }





    }
}
