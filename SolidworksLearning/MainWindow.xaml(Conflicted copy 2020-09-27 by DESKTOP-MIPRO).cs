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
                    API_Learn.Learn_Sldworks.OpenDoc(swApp);
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
                        swApp.SetUserPreferenceToggle(10, false);
                        API_Learn.Learn_SketchManager.AddConstraintAndDim(SketchDoc);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        swApp.SetUserPreferenceToggle(10, true);
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
        }
    }
}
