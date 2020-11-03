using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidworksLearning.API_Learn
{
    public class Learn_FeatureManager
    {
        public static void CreateFeature1(ModelDoc2 FeatDoc)
        {
            FeatureManager SwFeatMrg = FeatDoc.FeatureManager;
            Feature SwSektchFeat = ((PartDoc)FeatDoc).FeatureByName("草图1");
            SwSektchFeat.Select(false);
            Feature SwFeat = SwFeatMrg.FeatureExtrusion3(true, false, false, 0, 0, 0.01, 0.01, false, false, false, false, 0,0, false, false, false, false, true, true, true, 0, 0, false);
        }
        public static void CreatePlane(ModelDoc2 FeatDoc)
        {
            SketchManager SwSketchMrg = FeatDoc.SketchManager;//获得SketchManager对象
            FeatDoc.Extension.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            SwSketchMrg.InsertSketch(true);//进入编辑草图模式
            SwSketchMrg.CreateLine(0, 0, 0,0.01, 0.01, 0);
            SwSketchMrg.InsertSketch(true);//退出编辑草图模式
            FeatDoc.ClearSelection2(true);
            FeatureManager SwFeatMrg = FeatDoc.FeatureManager;
            FeatDoc.Extension.SelectByID2("Point2@草图1", "EXTSKETCHPOINT", 0, 0, 0,false, 0, null, 0);
            FeatDoc.Extension.SelectByID2("Line1@草图1", "EXTSKETCHSEGMENT", 0, 0, 0,true, 1, null, 0);
            SwFeatMrg.InsertRefPlane(4, 0, 2, 0, 0, 0);
        }

    }
}
