using System;
using System.Web.Mvc;
using Orchard.Net.Dev.Test.Models;

namespace Orchard.Net.Dev.Test.Controllers.Web
{
    public class UserParameterInjector : FilterAttribute, IActionFilter
    {
        private readonly string _parameterName;

        public UserParameterInjector(string parameterName)
        {
            _parameterName = parameterName;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var valueProviderResult = filterContext.Controller.ValueProvider.GetValue(_parameterName);

            filterContext.ActionParameters[_parameterName] = ApplicationUser.GetId();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}