using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TaskManager.Domain.CommonEntities;
using TaskManager.Domain.Entities;
using TaskManager.WebApp.Interfaces;
using TaskManager.WebApp.Mappings;
using TaskManager.WebApp.Middleware;
using TaskManager.WebApp.Persistence.EntityFramework.Context;
using TaskManager.WebApp.Wrappers;

namespace TaskManager.WebApp.Features.Spaces
{
    public static class CreateSpace
    {
        public record CreateSpaceRequest(string Title, string Description, Guid UserId);

        public partial class CreateSpaceEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder.MapPost("Space/Create", HandlerAsync)
                    .AddEndpointFilter<ValidatorFilter<CreateSpaceRequest>>();
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

        public static async Task<Results<Created, BadRequest<AppResponse<Empty>>>> HandlerAsync(CreateSpaceRequest request, AppDbContext context)
        {
            var space = request.ToSpace();

            await context.Set<Space>().AddAsync(space);
            var result = await context.SaveChangesAsync();

            if (result < 1)
                return TypedResults.BadRequest(AppError.WithMessage("There was a problem creating the space")
                    .CreateResponse<Empty>(HttpStatusCode.BadRequest));

            return TypedResults.Created();
        }
    }
}
