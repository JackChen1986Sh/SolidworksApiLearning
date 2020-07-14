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
            CreateLessonRow("Solidworks应用程序对象", "初识SldWorks对象", "新建", "获取", "");
         


        }
        public void CreateLessonRow(string an,string ad,string s1,string s2,string s3)
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
            if (rowindex == 0)//1.Solidworks应用程序对象--初识SldWorks对象
            {
                if (sampleindex == 1)//新建
                {
                    SldWorks swApp=  API_Learn.Learn_Sldworks.NewSolidworksApp();
                    swApp.NewPart();//新建零件,验证获得Solidworks程序对象成功
                }
                else if(sampleindex == 2)
                {
                    SldWorks swApp=API_Learn.Learn_Sldworks.GetSolidworksApp();
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



        }




    }
}
