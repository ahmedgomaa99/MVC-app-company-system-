using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace app1.Filtters
{
    public class HandleErrorMetaData : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult c=new ContentResult();
            //c.Content = "throw New ExpETION";

            //context.Result = c; 


            ViewResult viewResult = new ViewResult();

            viewResult.ViewName = "Error";

            context.Result = viewResult;

        }
    }

        public class my_filter : Attribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
            }

           
        }
}
