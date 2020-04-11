using Medium.Common.DTO;
using Medium.Common.Helper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Medium.Helper
{
    public class ResponseWrapper
    {
        private readonly RequestDelegate _next;

        public ResponseWrapper(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var currentBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await _next(context);

                context.Response.Body = currentBody;
                memoryStream.Seek(0, SeekOrigin.Begin);

                var readToEnd = new StreamReader(memoryStream).ReadToEnd();

                object objResult = null;

                if (readToEnd.ValidateJSON())
                {
                    objResult = JsonConvert.DeserializeObject(readToEnd);
                }
                else
                {
                    objResult = readToEnd;
                }

                string errorMessage = string.Empty;
                string correletionId = string.Empty;
                if (context.Items["exception"] != null)
                {
                    errorMessage = context.Items["exceptionMessage"].ToString();
                    correletionId = context.Items["correlationId"].ToString();
                }
                
                var result = CommonApiResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult, errorMessage, correletionId);

                context.Response.ContentType = "application/json";


                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
        }

    }
}
