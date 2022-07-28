using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EvaluationProduit.MVC.Filters
{
    public class ProduitActionFilter : ActionFilterAttribute
    {
        private IHostingEnvironment _environment;

        public ProduitActionFilter(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            using (FileStream fs = new FileStream("c:\\logs\\log.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(actionName + $" Début {_environment.EnvironmentName}");
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            using (FileStream fs = new FileStream("c:\\logs\\log.txt", FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(actionName + " Fin");
                }
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            using (FileStream fs = new FileStream("c:\\logs\\log.txt", FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("OnResultExecuting");
                }
            }
        }
        //public override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    var result = (ContentResult)filterContext.Result;
        //    using (FileStream fs = new FileStream("c:\\logs\\log.txt", FileMode.Append))
        //    {
        //        using (StreamWriter sw = new StreamWriter(fs))
        //        {
        //            sw.WriteLine("Résultat: " + result.Content);
        //        }
        //    }
        //}
    }
}
