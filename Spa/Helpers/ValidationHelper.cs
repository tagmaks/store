using System.Web.Http.ModelBinding;
using GenericLibsBase;

namespace Spa.Helpers
{
    public static class ValidationHelper
    {
        public static void CopyErrorsToModelState(this ISuccessOrErrors errorHolder, ModelStateDictionary modelState)
        {
            if (errorHolder.IsValid) return;

            foreach (var error in errorHolder.Errors)
                modelState.AddModelError("", error.ErrorMessage);
        }
    }
}