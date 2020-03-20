using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Core.Entities;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Webapi.Attributes
{
    public class ExceptionLoggerAttribute : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var unitOfWork = (IUnitOfWork)context.HttpContext.RequestServices.GetService(typeof(IUnitOfWork));

            var entity = new ExceptionLog
            {
                Controller = context.RouteData.Values["controller"].ToString(),
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            await unitOfWork.ExceptionLogRepository.Create(entity);
            await unitOfWork.SaveChangesAsync();

            await base.OnExceptionAsync(context);
        }
    }
}
