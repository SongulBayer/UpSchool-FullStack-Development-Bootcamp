using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        //Requeste girerken önce buraya girecek.
        //onexecuted işlem bittikten sonra validasyonlara bakar
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors =context. ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
//context işlemi kullandığın yeri temsil eder
//request nereye gelmişse orayı temsil eder