using System.Net;

namespace Medium.Common.DTO
{
    public class CommonApiResponse
    {
        public static CommonApiResponse Create(HttpStatusCode statusCode, object result = null, string errorMessage = null,string correletionId = null,string errorCode = null)
        {
            return new CommonApiResponse(statusCode, result, errorMessage,correletionId,errorCode);
        }
        public string Version => "1.0";
        public string ErrorMessage { get; set; }
        public string CorreletionId { get; set; }

        public object Result { get; set; }

        protected CommonApiResponse(HttpStatusCode statusCode, object result = null, string errorMessage = null,string correletionId = null,string errorCode = null)
        {
            CorreletionId = correletionId;
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}
