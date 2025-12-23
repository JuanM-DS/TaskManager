using System.Net;

namespace TaskManager.WebApp.Wrappers
{
    public record AppResponse<T>(T? Data, HttpStatusCode HttpStatusCode, List<AppError>? AppErrors = null);

    public static class AppResponseExt
    {
        public static AppResponse<T> CreateResponse<T>(this AppError appError, T data, HttpStatusCode httpStatusCode)
            => new AppResponse<T>(data, httpStatusCode);

        public static AppResponse<T> CreateResponse<T>(this List<AppError> appError, T data, HttpStatusCode httpStatusCode)
            => new AppResponse<T>(data, httpStatusCode);
    }
}
