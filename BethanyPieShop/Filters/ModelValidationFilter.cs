using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BethanyPieShop.Filters {
  public class ModelValidationFilter : Attribute, IActionFilter {
    public void OnActionExecuted (ActionExecutedContext context) {
      throw new NotImplementedException ();
    }

    public void OnActionExecuting (ActionExecutingContext context) {
      if (!context.ModelState.IsValid) {
        context.Result = new ViewResult () {
          ViewData = ((Controller) context.Controller).ViewData,
          TempData = ((Controller) context.Controller).TempData,
          StatusCode = 400
        };
      }
    }
  }
}