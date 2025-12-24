
using FluentValidation;
using System.Net;
using TaskManager.Domain.CommonEntities;
using TaskManager.WebApp.Wrappers;

namespace TaskManager.WebApp.Middleware
{
    public class ValidatorFilter<T> : IEndpointFilter
    {
        private readonly IValidator<T> _validator;

        public ValidatorFilter(IValidator<T> Validator)
        {
            _validator = Validator;
        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var request = context.Arguments.OfType<T>().Single();

            var result = await _validator.ValidateAsync(request);
            
            if (result.IsValid)
                return next(context);

            var errors = result.Errors;
            var response = errors
                .Select(x => 
                    AppError
                        .WithMessage(x.ErrorMessage)
                        .For(x.PropertyName))
                .ToList()
                .CreateResponse<Empty>(HttpStatusCode.BadRequest);

            return Results.BadRequest(response);
        }
    }
}
