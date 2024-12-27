using AutoMapper;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Application.DTOs.Task;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Mappings;

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        // project mapping
        CreateMap<ProjectDTO, ProjectModel>().ReverseMap();
        CreateMap<CreatingProjectDTO, ProjectModel>().ReverseMap();
        
        // task mapping
        CreateMap<TaskDTO, ProjectModel>().ReverseMap();
    }
}
