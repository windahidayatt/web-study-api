using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace web_study_api.Models.Base
{

    [DefaultStatusCode(DefaultStatusCode)]
    public class SuccessApiResponse : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status200OK;
        public SuccessApiResponse(string message, object data = null) : base(new { message, data })
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
