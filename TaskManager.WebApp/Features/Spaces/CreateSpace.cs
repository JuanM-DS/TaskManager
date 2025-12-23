using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using TaskManager.WebApp.Interfaces;
using TaskManager.WebApp.Mappings;
using TaskManager.WebApp.Persistence.EntityFramework.Context;

namespace TaskManager.WebApp.Features.Spaces
{
    public static class CreateSpace
    {
        public record CreateSpaceRequest(string Title, string Description, Guid UserId);

        public partial class CreateSpaceEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder.MapPost("Space/Create", Handler);
            }
        }

        private class CreateSpaceRequestValidator : AbstractValidator<CreateSpaceRequest>
        {
            public CreateSpaceRequestValidator()
            {
                RuleFor(x => x.Title)
                    .NotEmpty()
                    .MaximumLength(40);

                RuleFor(x => x.Description)
                    .NotEmpty()
                    .MaximumLength(100);

                RuleFor(x => x.UserId)
                    .NotEmpty()
                    .NotNull();
            }
        }

        public static async Task<Results<Created, BadRequest>> HandlerAsync(CreateSpaceRequest request, AppDbContext context, IValidator<CreateSpaceRequest> validator)
        {
            if(await validator.ValidateAsync(request))

            var space = request.ToSpace();
        }
    }
}
