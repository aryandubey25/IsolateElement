using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;

namespace IsolateElement
{
    [Transaction(TransactionMode.Manual)]
    public class CheckElementCommand : IExternalCommand
    {
        private static List<ElementId> hiddenElements = new List<ElementId>();
        private static bool isIsolated = false;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            if (isIsolated)
            {
                
                using (Transaction t = new Transaction(doc, "Unhide Elements"))
                {
                    t.Start();
                    foreach (var hiddenElementId in hiddenElements)
                    {
                        doc.ActiveView.UnhideElements(new List<ElementId> { hiddenElementId });
                    }
                    hiddenElements.Clear();
                    t.Commit();
                }
                isIsolated = false;
                TaskDialog.Show("Isolate Element", "All elements restored.");
            }
            else
            {
                try
                {
                    Reference pickedRef = uidoc.Selection.PickObject(ObjectType.Element, "Select an element to isolate");
                    Element selectedElement = doc.GetElement(pickedRef.ElementId);

                   
                    using (Transaction t = new Transaction(doc, "Isolate Element"))
                    {
                        t.Start();
                        
                        FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id)
                            .WhereElementIsNotElementType()
                            .Excluding(new List<ElementId> { selectedElement.Id });

                        
                        foreach (Element e in collector)
                        {
                            doc.ActiveView.HideElements(new List<ElementId> { e.Id });
                            hiddenElements.Add(e.Id);
                        }

                        t.Commit();
                    }

                    isIsolated = true;
                    TaskDialog.Show("Isolate Element", $"Element {selectedElement.Name} is now isolated.");
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return Result.Failed;
                }
            }

            return Result.Succeeded;
        }
    }
}
