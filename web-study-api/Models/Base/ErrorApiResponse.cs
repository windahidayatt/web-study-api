using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace web_study_api.Models.Base
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class ErrorApiResponse : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;

        public ErrorApiResponse(string message, object data = null) : base(new { message, data })
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
