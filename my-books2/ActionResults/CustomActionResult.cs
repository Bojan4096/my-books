using Microsoft.AspNetCore.Mvc;
using my_books2.Data.ViewModels;

namespace my_books2.ActionResults
{
    public class CustomActionResult : IActionResult
    {
        private readonly CustomActionResultVM _result;

        public CustomActionResult(CustomActionResultVM result)
        {
            _result = result;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result.exception ?? _result.publisher as object)
            {
                StatusCode = _result.exception != null ? StatusCodes.Status500InternalServerError : StatusCodes.Status200OK
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
