using Microsoft.AspNetCore.Mvc.Filters;

namespace Rooydaad.Web.Infrustructure.Filters
{
    public class PoweredByFilters:ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("PowerdBy", "Behzad");
            base.OnResultExecuting(context);
        }
        //public override void OnResultExecuted(ResultExecutedContext context)
        //{
        //    base.OnResultExecuted(context);
        //}
    }
}
