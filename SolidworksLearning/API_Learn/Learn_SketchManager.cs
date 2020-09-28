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

        public static void AddConstraintAndDim(ModelDoc2 SketchDoc)
        {
            SketchManager SwSketchMrg = SketchDoc.SketchManager;//获得SketchManager对象
            SketchDoc.Extension.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            SwSketchMrg.InsertSketch(true);//进入编辑草图模式
            object[] ObjRectangle = SwSketchMrg.CreateCenterRectangle(0, 0, 0, 0.075, 0.04, 0);
            SketchSegment SktCircle1 = SwSketchMrg.CreateCircle(-0.0425, 0, 0, -0.03, 0, 0);
            SketchSegment SktCircle2 = SwSketchMrg.CreateCircle(0.0425, 0, 0, 0.03, 0, 0);
            SketchSegment SktCentLine = SwSketchMrg.CreateCenterLine(0, 0.04, 0, 0, -0.04, 0);

            #region 两个圆心添加水平
            SketchDoc.ClearSelection2(true);
            SketchDoc.Extension.SelectByID2("", "SKETCHPOINT", -0.0425, 0, 0, true, 0, null, 0);
            SketchDoc.Extension.SelectByID2("", "SKETCHPOINT", 0.0425, 0, 0, true, 0, null, 0);
            SketchDoc.SketchAddConstraints("sgHORIZONTALPOINTS2D");
            #endregion

            #region 两个圆心添加对称
            SketchDoc.ClearSelection2(true);
            SketchDoc.Extension.SelectByID2("", "SKETCHPOINT", -0.0425, 0, 0, true, 0, null, 0);
            SketchDoc.Extension.SelectByID2("", "SKETCHPOINT", 0.0425, 0, 0, true, 0, null, 0);
            SktCentLine.Select(true);
            SketchDoc.SketchAddConstraints("sgSYMMETRIC");
            #endregion

            #region 圆心与坐标原点水平
            SketchDoc.ClearSelection2(true);
            SketchDoc.Extension.SelectByID2("", "SKETCHPOINT", -0.0425, 0, 0, true, 0, null, 0);
            SketchDoc.Extension.SelectByID2("", "SKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            SketchDoc.SketchAddConstraints("sgHORIZONTALPOINTS2D");
            #endregion

            #region 添加孔间距尺寸
            SketchDoc.ClearSelection2(true);
            SketchDoc.Extension.SelectByID2("", "SKETCHPOINT", -0.0425, 0, 0, true, 0, null, 0);
            SketchDoc.Extension.SelectByID2("", "SKETCHPOINT", 0.0425, 0, 0, true, 0, null, 0);
            SketchDoc.AddDimension2(0, 0.05, 0);
            #endregion

            #region 两个圆添加相同大小
            SktCircle1.Select(false);
            SktCircle2.Select(true);
            SketchDoc.SketchAddConstraints("sgSAMELENGTH");
            #endregion

            #region 添加圆尺寸
            SktCircle1.Select(false);
            SketchDoc.AddDimension2(-0.02, 0.02, 0);
            #endregion

            #region 添加矩形长
            SketchDoc.Extension.SelectByID2("", "SKETCHSEGMENT", -0.02, 0.04, 0, false, 0, null, 0);
            SketchDoc.AddDimension2(0, 0.07, 0);
            #endregion

            #region 添加矩形高
            SketchDoc.Extension.SelectByID2("", "SKETCHSEGMENT", 0.075,0 , 0, false, 0, null, 0);
            SketchDoc.AddDimension2(0.09, 0, 0);
            #endregion

            SwSketchMrg.InsertSketch(true);//退出编辑草图模式
        }
       


    }
}
