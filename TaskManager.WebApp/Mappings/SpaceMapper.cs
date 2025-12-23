using TaskManager.Domain.Entities;
using static TaskManager.WebApp.Features.Spaces.CreateSpace;

namespace TaskManager.WebApp.Mappings
{
    public static class SpaceMapper
    {
        public static Space ToSpace(this CreateSpaceRequest request)
            => new Space(request.Title, request.Description, request.UserId);

        public static CreateSpaceRequest ToSpaceDTO(this Space space)
            => new CreateSpaceRequest(space.Title, space.Description, space.UserId);
    }
}
