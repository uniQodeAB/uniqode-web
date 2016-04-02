﻿using System;
using System.Web.Mvc;

namespace UniQode.Web.Attributes
{
    /// <summary>
    /// An Action Filter for importing ModelState from TempData.
    /// You need to decorate your GET actions with this when using the <see cref="ValidateModelStateAttribute"/>.
    /// 
    /// Made by Ben Foster at https://github.com/benfoster/Fabrik.Common
    /// </summary>
    /// <remarks>
    /// Useful when following the PRG (Post, Redirect, Get) pattern.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ImportModelStateFromTempDataAttribute : ModelStateTempDataTransfer
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Only copy from TempData if we are rendering a View/Partial
            if (filterContext.Result is ViewResult)
            {
                ImportModelStateFromTempData(filterContext);
            }
            else
            {
                // remove it
                RemoveModelStateFromTempData(filterContext);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}