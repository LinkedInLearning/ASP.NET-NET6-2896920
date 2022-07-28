using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EvaluationProduit.MVC.Exceptions
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var result = new ViewResult { ViewName = "InvalidModel" };
                context.Result = result;
                context.ExceptionHandled = true;
            }
        }
    }
}

