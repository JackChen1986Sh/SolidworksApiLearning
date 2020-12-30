using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

using System.Data;

namespace SolidworksLearning
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable LessonDt = new DataTable();
        public MainWindow()
        {
            //搜索框筛选文章，按钮点击
            InitializeComponent();

            LessonDt.Columns.Add("ID", Type.GetType("System.Int32"));//序号
            LessonDt.Columns.Add("ArticleName", Type.GetType("System.String"));//微信文章名称
            LessonDt.Columns.Add("ArticleDesc", Type.GetType("System.String"));//微信文章主要接口
            LessonDt.Columns.Add("SampleName1", Type.GetType("System.String"));//示例1，功能序号1
            LessonDt.Columns.Add("SampleName2", Type.GetType("System.String"));//示例2，功能序号2
            LessonDt.Columns.Add("SampleName3", Type.GetType("System.String"));//示例3，功能序号3


            InitLesson();

            dgv_articlelist.ItemsSource = LessonDt.AsDataView();
        }
        public void InitLesson()
        {
            CreateLessonRow("1.Solidworks应用程序对象", "SldWorks对象初识", "新建", "获取", "无");
            CreateLessonRow("2.Solidworks应用程序对象", "SldWorks文档操作1", "新建文档", "打开文档", "所有文档");
            CreateLessonRow("3.Solidworks应用程序对象", "SldWorks文档操作2", "文档切换", "加载文档", "关闭文档");
            CreateLessonRow("4.Solidworks应用程序对象", "SldWorks文档与系统设置", "系统设置", "无", "无");
            CreateLessonRow("5.Solidworks文档相关对象简介", "ModelDoc2及相关文档对象", "获取文档", "无", "无");
            CreateLessonRow("6.Solidworks草图绘制基础1", "SketchManager对象", "草图绘制", "无", "无");
            CreateLessonRow("7.Solidworks草图绘制基础2", "几何关系与尺寸添加", "示例", "无", "无");
            CreateLessonRow("8.Solidworks特征创建简介", "FeatureManager对象", "拉伸", "基准面", "无");
            CreateLessonRow("9.Solidworks属性", "CustomPropertyManager对象", "写入", "读取", "无");
            CreateLessonRow("10.Solidworks配置", "ConfigurationManager对象", "创建配置", "获取配置", "删除配置");
            CreateLessonRow("11.Solidworks获取选择", "SelectionMgr对象", "获取面", "获取边线","选择集");
            //CreateLessonRow("12.Solidworks测量工具", "Measure对象", "圆柱", "边线", "圆柱与点");
        }
        public void CreateLessonRow(string an, string ad, string s1, string s2, string s3)
        {
            DataRow dr = LessonDt.NewRow();
            dr["ID"] = (LessonDt.Rows.Count + 1).ToString().Trim();
            dr["ArticleName"] = an;
            dr["ArticleDesc"] = ad;
            dr["SampleName1"] = s1;
            dr["SampleName2"] = s2;
            dr["SampleName3"] = s3;
            LessonDt.Rows.Add(dr);
        }


        private void Sample1_Click(object sender, RoutedEventArgs e)
        {
            DoFunc(dgv_articlelist.SelectedIndex, 1);
        }

        private void Sample2_Click(object sender, RoutedEventArgs e)
        {
            DoFunc(dgv_articlelist.SelectedIndex, 2);
        }

        private void Sample3_Click(object sender, RoutedEventArgs e)
        {
            DoFunc(dgv_articlelist.SelectedIndex, 3);
        }

        public void DoFunc(int rowindex, int sampleindex)
        {
            #region 1.Solidworks应用程序对象--初识SldWorks对象
            if (rowindex == 0)//
            {
                if (sampleindex == 1)//新建
                {
                    SldWorks swApp = API_Learn.Learn_Sldworks.NewSolidworksApp();
                    swApp.NewPart();//新建零件,验证获得Solidworks程序对象成功
                }
                else if (sampleindex == 2)
                {
                    SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                    if (swApp != null)
                    {
                        swApp.NewPart();//新建零件,验证获得Solidworks程序对象成功
                    }
                    else
                    {
                        MessageBox.Show("无打开的Solidworks");
                    }
                }
            }
            #endregion
            #region 2.Solidworks应用程序对象--文档操作1
            else if (rowindex == 1)//
            {
                SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                if (sampleindex == 1)//新建
                {
                    API_Learn.Learn_Sldworks.NewDoc(swApp);
                }
                else if (sampleindex == 2)//打开
                {
                    API_Learn.Learn_Sldworks.OpenDoc(swApp, AppDomain.CurrentDomain.BaseDirectory + @"RectanglePlug\PlugTopBox.SLDPRT", true);
                }
                else if (sampleindex == 3)//所有文档
                {
                    API_Learn.Learn_Sldworks.GetAllOpenedDoc(swApp);
                }
            }
            #endregion
            #region 3.Solidworks应用程序对象--文档操作2
            else if (rowindex == 2)//
            {
                SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                if (sampleindex == 1)//文档切换
                {
                    API_Learn.Learn_Sldworks.ActivateDoc(swApp);
                }
                else if (sampleindex == 2)//加载
                {
                    API_Learn.Learn_Sldworks.LoadThirdPartFile(swApp);
                }
                else if (sampleindex == 3)//关闭
                {
                    API_Learn.Learn_Sldworks.CloseDoc(swApp);
                }
            }
            #endregion
            #region 4.Solidworks应用程序对象--文档与系统设置
            else if (rowindex == 3)//
            {
                SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                if (sampleindex == 1)//系统设置
                {
                    API_Learn.Learn_Sldworks.SystamSet(swApp);
                }
                else if (sampleindex == 2)//文档设置
                {

                }
                else if (sampleindex == 3)//
                {

                }
            }
            #endregion
            #region 5.Solidworks文档相关对象简介
            else if (rowindex == 4)//
            {
                SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                if (sampleindex == 1)//获取文档
                {
                    API_Learn.Learn_ModelDoc2.GetDocObject(swApp);
                }
                else if (sampleindex == 2)//
                {

                }
                else if (sampleindex == 3)//
                {

                }
            }
            #endregion
            #region 6.Solidworks草图绘制基础1
            else if (rowindex == 5)//
            {
                if (sampleindex == 1)//草图绘制
                {
                    SldWorks swApp = API_Learn.Learn_Sldworks.NewSolidworksApp();
                    ModelDoc2 SketchDoc = swApp.NewPart();//新建零件,验证获得Solidworks程序对象成功
                    API_Learn.Learn_SketchManager.DrawSketch(SketchDoc);
                }
                else if (sampleindex == 2)//
                {

                }
                else if (sampleindex == 3)//
                {

                }
            }
            #endregion
            #region 7.Solidworks草图绘制基础2
            else if (rowindex == 6)//
            {
                if (sampleindex == 1)//添加集合关系与尺寸
                {
                    SldWorks swApp = API_Learn.Learn_Sldworks.NewSolidworksApp();
                    ModelDoc2 SketchDoc = swApp.NewPart();//新建零件,验证获得Solidworks程序对象成功
                    try
                    {
                        swApp.SetUserPreferenceToggle(10, false);//不弹出尺寸标注对话框
                        API_Learn.Learn_SketchManager.AddConstraintAndDim(SketchDoc);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        swApp.SetUserPreferenceToggle(10, true);//恢复弹出尺寸标注对话框
                    }
                }
                else if (sampleindex == 2)//
                {

                }
                else if (sampleindex == 3)//
                {

                }
            }
            #endregion
            #region 8.Solidworks特征创建基础1
            else if (rowindex == 7)//
            {
                if (sampleindex == 1)//拉伸特征
                {
                    SldWorks swApp = API_Learn.Learn_Sldworks.NewSolidworksApp();
                    ModelDoc2 FeatDoc = swApp.NewPart();//新建零件,验证获得Solidworks程序对象成功
                    try
                    {
                        swApp.SetUserPreferenceToggle(10, false);//不弹出尺寸标注对话框
                        API_Learn.Learn_SketchManager.AddConstraintAndDim(FeatDoc);
                        FeatDoc.ClearSelection2(true);
                        API_Learn.Learn_FeatureManager.CreateFeature1(FeatDoc);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        swApp.SetUserPreferenceToggle(10, true);//恢复弹出尺寸标注对话框
                    }
                }
                else if (sampleindex == 2)//基准
                {
                    SldWorks swApp = API_Learn.Learn_Sldworks.NewSolidworksApp();
                    ModelDoc2 FeatDoc = swApp.NewPart();//新建零件,验证获得Solidworks程序对象成功
                    try
                    {
                        API_Learn.Learn_FeatureManager.CreatePlane(FeatDoc);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        swApp.SetUserPreferenceToggle(10, true);//恢复弹出尺寸标注对话框
                    }
                }
                else if (sampleindex == 3)//
                {

                }
            }
            #endregion
            #region 9.Solidworks属性
            else if (rowindex == 8)//
            {
                SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                ModelDoc2 Doc = swApp.ActiveDoc;
                bool ToOpen = false;
                if (Doc == null)
                {
                    ToOpen = true;
                }
                else
                {
                    if (Doc.GetTitle() != "Solidworks属性学习.SLDPRT")
                    {
                        ToOpen = true;
                    }
                }
                if (ToOpen)
                {
                    Doc = API_Learn.Learn_Sldworks.OpenDoc(swApp, AppDomain.CurrentDomain.BaseDirectory + @"Sample\9\Solidworks属性学习.SLDPRT", false);
                }

                if (Doc != null)
                {
                    if (sampleindex == 1)//属性写入
                    {
                        API_Learn.Learn_CustomPropertyManager.WriteCusp(Doc);
                    }
                    else if (sampleindex == 2)//属性读取
                    {
                        API_Learn.Learn_CustomPropertyManager.ReadCusp(Doc);
                    }
                }
            }
            #endregion
            #region 9.Solidworks配置
            else if (rowindex == 9)//
            {
                SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                ModelDoc2 Doc = swApp.ActiveDoc;
                bool ToOpen = false;
                if (Doc == null)
                {
                    ToOpen = true;
                }
                else
                {
                    if (Doc.GetTitle() != "ConfigPart.SLDPRT")
                    {
                        ToOpen = true;
                    }
                }
                if (ToOpen)
                {
                    Doc = API_Learn.Learn_Sldworks.OpenDoc(swApp, AppDomain.CurrentDomain.BaseDirectory + @"Sample\10\ConfigPart.SLDPRT", false);
                }

                if (Doc != null)
                {
                    if (sampleindex == 1)//创建配置
                    {
                        API_Learn.Learn_Configuration.CreateConfig(Doc);
                    }
                    else if (sampleindex == 2)//读取配置
                    {
                        API_Learn.Learn_Configuration.GetConfig(Doc);
                    }
                    else if (sampleindex == 3)//删除配置
                    {
                        API_Learn.Learn_Configuration.DelConfig(Doc);
                    }
                }
            }
            #endregion
            #region 10.获取选择对象
            else if (rowindex == 10)//
            {
                SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                ModelDoc2 Doc = swApp.ActiveDoc;
                bool ToOpen = false;
                if (Doc == null)
                {
                    ToOpen = true;
                }
                else
                {
                    if (Doc.GetTitle() != "SelectionMgr.SLDPRT")
                    {
                        ToOpen = true;
                    }
                }
                if (ToOpen)
                {
                    Doc = API_Learn.Learn_Sldworks.OpenDoc(swApp, AppDomain.CurrentDomain.BaseDirectory + @"Sample\11\SelectionMgr.SLDPRT", false);
                }

                if (Doc != null)
                {
                    if (sampleindex == 1)//获取面
                    {
                        API_Learn.Learn_SelectionMgr.GetFace(Doc);
                    }
                    else if (sampleindex == 2)//获取边线
                    {
                        API_Learn.Learn_SelectionMgr.GetEdge(Doc);
                    }
                    else if (sampleindex == 3)//
                    {
                        API_Learn.Learn_SelectionMgr.GetSelectList(Doc);
                    }
                }
            }
            #endregion
            #region 11.Solidworks测量工具
            else if (rowindex == 11)//
            {
                SldWorks swApp = API_Learn.Learn_Sldworks.GetSolidworksApp();
                ModelDoc2 Doc = swApp.ActiveDoc;
                bool ToOpen = false;
                if (Doc == null)
                {
                    ToOpen = true;
                }
                else
                {
                    if (Doc.GetTitle() != "Measure.SLDPRT")
                    {
                        ToOpen = true;
                    }
                }
                if (ToOpen)
                {
                    Doc = API_Learn.Learn_Sldworks.OpenDoc(swApp, AppDomain.CurrentDomain.BaseDirectory + @"Sample\12\Measure.SLDPRT", false);
                }

                if (Doc != null)
                {
                    if (sampleindex == 1)//圆柱
                    {
                        API_Learn.Learn_Measure.MeasureFace(Doc);
                    }
                    else if (sampleindex == 2)//边线
                    {
                        API_Learn.Learn_Measure.MeasureEdge(Doc);
                    }
                    else if (sampleindex == 3)//圆柱与点
                    {
                        API_Learn.Learn_Measure.MeasurePointFace(Doc);
                    }
                }
            }
            #endregion





        }
    }
}
