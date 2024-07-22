using FullStackTest.Services.Models;
using FullStackTest.Services.Models.DbContexts;
using FullStackTest.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FullStackTest.Services.Services
{
    public interface IProjectService
    {
        List<Models.TaskStatus> GetTaskStatuses();
        Task<List<Project>> SaveProject(SaveProjectRequest project);
        List<Project> GetProjects();
        Task<List<ProjectTask>> SaveTask(SaveTaskRequest projectTask);
        List<ProjectTask> GetTasksByProjectId(Guid projectId);
    }

    public class ProjectService(IDbContextFactory<ProjectManagementDbContext> projectManagementDbContext)
        : IProjectService
    {
        public List<Models.TaskStatus> GetTaskStatuses()
        {
            using var context = projectManagementDbContext.CreateDbContext();
            return context.Statuses.ToList();
        }

        public List<Project> GetProjects()
        {
            using var context = projectManagementDbContext.CreateDbContext();
            return context.Projects.ToList();
        }

        public List<ProjectTask> GetTasksByProjectId(Guid projectId)
        {
            using var context = projectManagementDbContext.CreateDbContext();
            return context.Tasks
                          .Include(t => t.Status)
                          .Where(task => task.ProjectId == projectId).ToList();
        }

        public async Task<List<Project>> SaveProject(SaveProjectRequest project)
        {
            using var context = projectManagementDbContext.CreateDbContext();

            Project projectDB = new();

            if (project.ProjectId.HasValue)
            {
                projectDB = context.Projects.First(p => p.Id == project.ProjectId);
                projectDB.Title = project.Title;
                projectDB.Description = project.Description;
                context.Projects.Update(projectDB);
            }
            else
            {
                projectDB.Title = project.Title;
                projectDB.Description = project.Description;
                projectDB.CreatedBy = project.SavedBy;
                context.Projects.Add(projectDB);
            }

            await context.SaveChangesAsync();

            return GetProjects();
        }

        public async Task<List<ProjectTask>> SaveTask(SaveTaskRequest projectTask)
        {
            using var context = projectManagementDbContext.CreateDbContext();

            ProjectTask taskDB = new();
            
            if (projectTask.TaskId.HasValue) 
            {
                taskDB = context.Tasks.First(task => task.Id == projectTask.TaskId);
                taskDB.StatusId = projectTask.StatusId;
                taskDB.Title = projectTask.Title;
                taskDB.Description = projectTask.Description;
                taskDB.ModifiedBy = projectTask.SavedBy;
                taskDB.ModifiedOn = DateTime.UtcNow;
                context.Tasks.Update(taskDB);
            } 
            else
            {
                taskDB.ProjectId = projectTask.ProjectId;
                taskDB.StatusId = projectTask.StatusId;
                taskDB.Title = projectTask.Title;
                taskDB.Description = projectTask.Description;
                taskDB.CreatedBy = projectTask.SavedBy;
                context.Tasks.Add(taskDB);
            }

            await context.SaveChangesAsync();

            return GetTasksByProjectId(projectTask.ProjectId);
        }
    }
}
