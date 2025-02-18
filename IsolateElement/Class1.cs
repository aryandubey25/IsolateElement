// <copyright file="Class1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace IsolateElement
{
    using System;
    using System.Reflection;
    using System.Windows.Media.Imaging;

#pragma warning disable SA1600 // Elements should be documented
    public class Class1 : IExternalApplication
#pragma warning restore SA1600 // Elements should be documented
    {
#pragma warning disable SA1600 // Elements should be documented
        public Result OnStartup(UIControlledApplication application)
#pragma warning restore SA1600 // Elements should be documented
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

#pragma warning disable SA1600 // Elements should be documented
        public Result OnShutdown(UIControlledApplication application)
#pragma warning restore SA1600 // Elements should be documented
        {
            return Result.Succeeded;
        }
    }

#pragma warning disable SA1600, SA1402, SA1401
    internal class PushButton
    {
        internal BitmapImage LargeImage;
    }
#pragma warning restore SA1600, SA1402, SA1401

#pragma warning disable SA1600, SA1402, SA1202, SA1201, SA1401
    internal class PushButtonData
    {
        private string v1;
        private string v2;
        private string thisAssemblyPath;
        private string v3;

        public PushButtonData(string v1, string v2, string thisAssemblyPath, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.thisAssemblyPath = thisAssemblyPath;
            this.v3 = v3;
        }
    }

    internal class RibbonPanel
    {
        internal PushButton AddItem(PushButtonData buttonData)
        {
            throw new NotImplementedException();
        }
    }

    public class UIControlledApplication
    {
        internal RibbonPanel CreateRibbonPanel(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Result
    {
        internal static Result Succeeded;
        internal static Result Failed;
    }

    public interface IExternalApplication
    {
    }
#pragma warning restore SA1600, SA1402, SA1202, SA1401, SA1201
}
