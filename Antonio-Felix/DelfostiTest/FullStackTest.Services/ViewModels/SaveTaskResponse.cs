using FullStackTest.Services.Models;

namespace FullStackTest.Services.ViewModels
{
    public class SaveTaskResponse : ResponseModel
    {
        public List<ProjectTask> Tasks { get; set; } = [];
    }
}
