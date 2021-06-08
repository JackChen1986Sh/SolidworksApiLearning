using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;



namespace SolidworksLearning.API_Learn
{
    public class Learn_Mate2
    {
        /// <summary>
        /// 获得配合类型
        /// </summary>
        /// <param name="SwComp"></param>
        public static void GetMateType(Component2 SwComp)
        {
            object[] CompMateObjs = SwComp.GetMates();
            foreach (object ObjMate in CompMateObjs)
            {
                if (ObjMate is Mate2)
                {
                    Mate2 SwMate = (Mate2)ObjMate;
                    System.Windows.MessageBox.Show(Enum.Parse(typeof(swMateType_e), SwMate.Type.ToString().Trim()).ToString().Trim());
                }
            }
        }



        /// <summary>
        /// 获得配合类型
        /// </summary>
        /// <param name="SwComp"></param>
        public static void GetMateRefrence(Component2 SwComp)
        {
            object[] CompMateObjs = SwComp.GetMates();
            StringBuilder Sb = new StringBuilder("");
            foreach (object ObjMate in CompMateObjs)
            {
                if (ObjMate is Mate2)
                {
                    Mate2 SwMate = (Mate2)ObjMate;
                    Sb.Append("配合【"+ ((Feature)SwMate).Name + "】参考对象:\r\n");//配合名称
                    int n = SwMate.GetMateEntityCount();
                    for(int i=0;i< n;i++)//配合参考
                    {
                        MateEntity2 SwMateEntity2 = SwMate.MateEntity(i);
                        
                        string reftype = Enum.Parse(typeof(swSelectType_e), SwMateEntity2.ReferenceType2.ToString().Trim()).ToString().Trim();
                        string comp = SwMateEntity2.ReferenceComponent.Name2;
                        string refname = SwMateEntity2.Reference.Name;
                        Sb.Append("部件【" + comp + "】，参考【" + refname + "】" + ",类型【" + reftype + "】");

                        DisplayDimension SwDispDim = SwMate.DisplayDimension2[0];
                        if (SwDispDim != null)
                        {
                            if (SwMate.Type == (int)swMateType_e.swMateANGLE)
                            {
                                Sb.Append(",角度=" + SwDispDim.GetDimension2(0).Value.ToString().Trim());
                            }
                            else if (SwMate.Type == (int)swMateType_e.swMateDISTANCE)
                            {
                                Sb.Append(",尺寸=" + SwDispDim.GetDimension2(0).Value.ToString().Trim());
                            }
                        }
                        Sb.Append("\r\n");
                    }
                    Sb.Append("\r\n");
                }
            }
            System.Windows.MessageBox.Show(Sb.ToString().Trim());
        }





    }
}
