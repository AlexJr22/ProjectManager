﻿using ProjetcManager.API.DTOs.Project;

namespace ProjetcManager.API.DTOs.Task;

public class TaskWithProjectDTO
{
    public int Id { get; set; }
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public bool TaskStatus { get; set; }
    public int? ProjectId { get; set; }
    public ProjectDTO? Project { get; set; }
}
