using System.Linq.Expressions;

namespace TaskManager.WebApp.Wrappers
{
    public record AppError(string Message, string? PropertyName)
    {
        public static AppError WithMessage(string message)
        {
            return new AppError
            (
                Message: message,
                PropertyName: null
            );
        }
    }

    public static class AppErrorExt
    {
        public static AppError For<T>(this AppError appError, Expression<Func<T, object>> propertyExpression)
        {
            var propertyName = propertyExpression.Body switch
            {
                MemberExpression m => m.Member.Name,
                UnaryExpression { Operand: MemberExpression m } => m.Member.Name,
                _ => null
            };

            return new AppError
            (
                Message: appError.Message,
                PropertyName: propertyName
            );
        }

        public static AppError For(this AppError appError, string propertyName)
        {
            return new AppError
            (
                Message: appError.Message,
                PropertyName: propertyName
            );
        }
    }
}
