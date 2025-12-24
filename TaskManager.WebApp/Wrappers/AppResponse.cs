using System.Net;

namespace TaskManager.WebApp.Wrappers
{
    public record AppResponse<T>(T? Data, HttpStatusCode HttpStatusCode, List<AppError>? AppErrors = null)
    {
        public static AppResponse<T> Create<T>(T? Data, HttpStatusCode HttpStatusCode)
            => new AppResponse<T>(Data, HttpStatusCode);
    }

    public static class AppResponseExt
    {
        public static AppResponse<T> CreateResponse<T>(this AppError appError, HttpStatusCode httpStatusCode)
            => new AppResponse<T>(default, httpStatusCode);

        public static AppResponse<T> CreateResponse<T>(this List<AppError> appError, HttpStatusCode httpStatusCode)
            => new AppResponse<T>(default, httpStatusCode);
    }
}
