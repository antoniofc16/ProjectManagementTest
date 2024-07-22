using FullStackTest.Services.Models;

namespace FullStackTest.Services.ViewModels
{
    public class ProjectsResponse : ResponseModel
    {
        public List<Project> Projects { get; set; } = [];
    }
}
