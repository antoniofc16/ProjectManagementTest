using FullStackTest.Services.Models;
using FullStackTest.Services.Services;
using FullStackTest.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackTest.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController (IProjectService ProjectService) : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetTaskStatuses()
        {
            var taskStatuses = ProjectService.GetTaskStatuses();
            return Ok(taskStatuses);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveProject([FromBody] SaveProjectRequest project)
        {
            SaveProjectResponse response = new();
            try
            {
                var projects = await ProjectService.SaveProject(project);

                response.Status = "Ok";
                response.Message = $"Se encontraron {projects.Count} registros";
                response.Projects = projects;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Message = $"Ocurrio un error inesperado: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveTask([FromBody] SaveTaskRequest task)
        {
            SaveTaskResponse response = new();
            try
            {
                var tasks = await ProjectService.SaveTask(task);

                response.Status = "Ok";
                response.Message = $"Se encontraron {tasks.Count} registros";
                response.Tasks = tasks;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Message = $"Ocurrio un error inesperado: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetProjects()
        {
            ProjectsResponse response = new();
            try
            {
                var projects = ProjectService.GetProjects();

                response.Status = "Ok";
                response.Message = $"Se encontraron {projects.Count} registros";
                response.Projects = projects;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Message = $"Ocurrio un error inesperado: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("[action]/{projectId}")]
        public IActionResult GetTasksByProjectId(string projectId)
        {
            TasksResponse response = new();
            try
            {
                Guid parsedProjectId;
                if (!Guid.TryParse(projectId, out parsedProjectId))
                {
                    response.Status = "Error";
                    response.Message = "El proyecto seleccionado no contiene tareas o no existe!";
                    return BadRequest(response);
                }

                var tasks = ProjectService.GetTasksByProjectId(parsedProjectId);

                response.Status = "Ok";
                response.Message = $"Se encontraron {tasks.Count} registros";
                response.Tasks = tasks;

                return Ok(response);
            }
            catch(Exception ex)
            {
                response.Status = "Error";
                response.Message = $"Ocurrio un error inesperado: {ex.Message}";
                return BadRequest(response);
            }
        }
    }
}
