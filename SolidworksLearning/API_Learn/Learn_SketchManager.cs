using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidworksLearning.API_Learn
{
    public class Learn_SketchManager
    {

        public static void DrawSketch(ModelDoc2 SketchDoc)
        {
            SketchManager SwSketchMrg = SketchDoc.SketchManager;//获得SketchManager对象
            SketchDoc.Extension.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            SwSketchMrg.InsertSketch(true);//进入编辑草图模式
            object[] ObjRectangle = SwSketchMrg.CreateCenterRectangle(0, 0, 0, 0.075, 0.04, 0);
            SketchSegment SktCircle1 = SwSketchMrg.CreateCircle(-0.0425, 0, 0, -0.03, 0, 0);
            SketchSegment SktCircle2 = SwSketchMrg.CreateCircle(0.0425, 0, 0, 0.03, 0, 0);
            SketchSegment SktCentLine = SwSketchMrg.CreateCenterLine(0, 0.04, 0, 0, -0.04, 0);
            SwSketchMrg.InsertSketch(true);//退出编辑草图模式

        }



    }
}
