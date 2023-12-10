using AutoMapper;

namespace TaskManager.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Core.Models.Project, Dtos.ProjectDto>().ReverseMap();
        CreateMap<Core.Models.User, Dtos.UserDto>().ReverseMap();
        CreateMap<Core.Models.UserTask, Dtos.UserTaskDto>().ReverseMap();
    }
}
