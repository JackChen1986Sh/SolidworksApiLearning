using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Diagnostics;
using System.Windows;

namespace SolidworksLearning.API_Learn
{
    public class Learn_Sldworks
    {

        public static SldWorks NewSolidworksApp()
        {
            SldWorks swApp;
            swApp = new SldWorks();
            //swApp.UserControl =true;
            swApp.Visible = true;
            return swApp;
        }
        public static SldWorks GetSolidworksApp()
        {
            SldWorks swApp;
            bool ExistSwApp = false;
            foreach (Process thisproc in Process.GetProcessesByName("SLDWORKS"))
            {
                ExistSwApp = true;
                break;
            }
            if (ExistSwApp)
            {
                Type swtype = Type.GetTypeFromProgID("SldWorks.Application");
                swApp = (SldWorks)Activator.CreateInstance(swtype);
                return swApp;
            }
            else
            {
                return null;
            }
        }
    }
}
