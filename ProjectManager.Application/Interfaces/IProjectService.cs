﻿using System.Linq.Expressions;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDTO>> GetAllAsync();
    Task<ProjectDTO> GetAsync(Expression<Func<ProjectModel, bool>> expression);
    Task<ProjectDTO> CreateAsync(CreatingProjectDTO project);
    Task<ProjectDTO> UpdateAsync(ProjectDTO project);
    Task<ProjectDTO> DeleteAsync(ProjectDTO project);
}
