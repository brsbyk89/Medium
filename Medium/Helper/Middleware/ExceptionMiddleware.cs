using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medium.Helper
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string errorMessage = string.Empty;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is MediumApiException)
                {
                    errorMessage = ex.Message;
                }
                else
                {
                    errorMessage = "Error";
                }

                context.Items.Add("exception", ex);
                context.Items.Add("exceptionMessage", errorMessage);
                context.Items.Add("correlationId", Guid.NewGuid());
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }

        }
    }
}
