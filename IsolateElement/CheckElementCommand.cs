using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows.Markup;

namespace IsolateElement
{
    public class CheckElementCommand : IExternalCommand
    {
        private static List<ElementId> hiddenElements = new List<ElementId>();
        private static bool isIsolated = false;
        private object ObjectType;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (isIsolated)
            {
                hiddenElements.Clear();
                isIsolated = false;
                TaskDialog.Show("Isolate Element", "All elements restored.");
            }
            else
            {
                try
                {
                    isIsolated = true;
                    TaskDialog.Show("Isolate Element", $"Element is now isolated.");
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return Result.Failed;
                }
            }

            return Result.Succeeded;
        }

        private class ElementId
        {
        }
    }
    public class ElementSet
    {
    }

    public class ExternalCommandData
    {
    }

    public interface IExternalCommand
    {
    }
}
