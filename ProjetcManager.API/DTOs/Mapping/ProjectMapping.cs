using ProjetcManager.API.DTOs.Project;
using ProjetcManager.API.Models;
using System.Linq;

namespace ProjetcManager.API.DTOs.Mapping;

public static class ProjectMapping
{
    public static ProjectDTO ToProjectDTO(this ProjectModel projetcModel)
    {
        ArgumentNullException.ThrowIfNull(projetcModel);

        return new ProjectDTO()
        {
            ProjectName = projetcModel.ProjectName,
            Id = projetcModel.Id,
        };
    }

    public static ProjectModel ToProjectModel(this ProjectDTO projectDTO)
    {
        ArgumentNullException.ThrowIfNull(projectDTO);

        return new ProjectModel()
        {
            ProjectName = projectDTO.ProjectName,
            Id = projectDTO.Id
        };
    }

    public static ProjectModel ToProjectModel(this ProjectDTOCreating projectDTO)
    {
        ArgumentNullException.ThrowIfNull(projectDTO);

        return new ProjectModel()
        {
            ProjectName = projectDTO.ProjectName
        };
    }

    public static IEnumerable<ProjectDTO> ToListProjectDTO(this IEnumerable<ProjectModel> projectModelList)
    {
        ArgumentNullException.ThrowIfNull(projectModelList);

        return projectModelList.Select(project => new ProjectDTO()
        {
            ProjectName = project.ProjectName,
            Id = project.Id
        });
    }

    public static IEnumerable<ProjectWithTasksDTO> ToListProjectWithTasksDTO(this IEnumerable<ProjectModel> projectModels)
    {
        ArgumentNullException.ThrowIfNull(projectModels);

        return projectModels.Select(project => new ProjectWithTasksDTO()
        {
            ProjectName = project.ProjectName,
            Id = project.Id,
            Tasks = project.Tasks!.ToListTaskDTO()
        });
    }

    public static IEnumerable<ProjectModel> ToListProjectModel(this IEnumerable<ProjectDTO> projectDTOList)
    {
        ArgumentNullException.ThrowIfNull(projectDTOList);

        return projectDTOList.Select(project => new ProjectModel()
        {
            ProjectName = project.ProjectName,
            Id = project.Id
        });
    }
}
