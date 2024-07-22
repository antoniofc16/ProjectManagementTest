using FullStackTest.Client.Models;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.ViewModels
{
    public class ProjectsResponse : ResponseModel
    {
        [JsonPropertyName("projects")]
        public List<Project> Projects { get; set; } = [];
    }
}
