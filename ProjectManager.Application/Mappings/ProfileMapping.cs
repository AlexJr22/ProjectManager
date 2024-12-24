using AutoMapper;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Application.DTOs.Task;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Mappings;

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<ProjectDTO, ProjectModel>().ReverseMap();
        CreateMap<TaskDTO, ProjectModel>().ReverseMap();
    }
}
