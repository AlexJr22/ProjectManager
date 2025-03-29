using System.Globalization;
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
        CreateMap<ProjectModel, ProjectDTO>()
            .ForMember(
                dest => dest.CreateAt,
                opt =>
                    opt.MapFrom(
                        src => src.CreateAt.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture)
                    )
            )
            .ReverseMap();

        CreateMap<ProjectModel, CreatingProjectDTO>().ReverseMap();
        CreateMap<ProjectModel, UpdateProjectDTO>().ReverseMap();
        CreateMap<UpdateProjectDTO, ProjectDTO>().ReverseMap();

        // task mapping
        CreateMap<TaskModel, TaskDTO>()
            .ForMember(
                dest => dest.CreateAt,
                opt =>
                    opt.MapFrom(
                        src => src.CreateAt.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture)
                    )
            )
            .ReverseMap();

        CreateMap<TaskModel, CreatingTaskDTO>().ReverseMap();
        CreateMap<TaskModel, UpdateTaskDTO>().ReverseMap();
        CreateMap<UpdateTaskDTO, TaskDTO>().ReverseMap();
    }
}
