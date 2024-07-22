using FullStackTest.Services.Models;

namespace FullStackTest.Services.ViewModels
{
    public class TasksResponse : ResponseModel
    {
        public List<ProjectTask> Tasks { get; set; } = [];
    }
}
