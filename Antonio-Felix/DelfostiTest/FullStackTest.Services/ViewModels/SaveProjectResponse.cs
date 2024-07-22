using FullStackTest.Services.Models;

namespace FullStackTest.Services.ViewModels
{
    public class SaveProjectResponse : ResponseModel
    {
        public List<Project> Projects { get; set; } = [];
    }
}
