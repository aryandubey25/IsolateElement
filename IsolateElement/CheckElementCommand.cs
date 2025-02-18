// <copyright file="CheckElementCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace IsolateElement
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Markup;

#pragma warning disable SA1600 // Elements should be documented
    public class CheckElementCommand : IExternalCommand
#pragma warning restore SA1600 // Elements should be documented
    {
        private static List<ElementId> hiddenElements = new List<ElementId>();
        private static bool isIsolated = false;

#pragma warning disable SA1600 // Elements should be documented
        public Result Execute()
#pragma warning restore SA1600 // Elements should be documented
        {
            if (isIsolated)
            {
                hiddenElements.Clear();
                isIsolated = false;
            }
            else
            {
                try
                {
                    isIsolated = true;
                }
                catch (Exception)
                {
                    return Result.Failed;
                }
            }

            return Result.Succeeded;
        }

        private class ElementId
        {
        }
    }

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1600 // Elements should be documented
    public interface IExternalCommand
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1201 // Elements should appear in the correct order
    {
    }
}