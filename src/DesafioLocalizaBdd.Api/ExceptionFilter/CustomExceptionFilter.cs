using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Net;

namespace DesafioLocalizaBdd.Api.ExceptionFilter
{
    /// <summary>
    /// Filtro de exceção customizado
    /// </summary>
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private const string DEFAULT_EXCEPTION = "Ocorreu um erro inesperado no sistema.";

        /// <summary>
        /// Sobrescrita do método OnException
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, context.Exception.Message);

            context.Result = new ObjectResult(new { message = context.Exception.Message ?? DEFAULT_EXCEPTION })
            {
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
