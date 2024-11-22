using ProjetcManager.API.Models;

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

    public static IEnumerable<ProjectDTO> ToListProjectDTO(this IEnumerable<ProjectModel> projectModelList)
    {
        ArgumentNullException.ThrowIfNull(projectModelList);

        return projectModelList.Select(project => new ProjectDTO()
        {
            ProjectName = project.ProjectName,
            Id = project.Id
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
