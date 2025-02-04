using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace IsolateElement
{
    public class Class1 : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Isolate Element");

            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdIsolateElement", "Isolate Element", thisAssemblyPath, "IsolateElement.CheckElementCommand");
            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

            
            Uri iconPath = new Uri(@"""C:\Users\Aryan.Dubey\Desktop\Revit Internship\Icons\Hierachy.png");
            BitmapImage buttonImage = new BitmapImage(iconPath);
            pushButton.LargeImage = buttonImage;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
