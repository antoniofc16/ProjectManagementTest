using FullStackTest.Client.Models;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.ViewModels
{
    public class TasksResponse : ResponseModel
    {
        [JsonPropertyName("tasks")]
        public List<ProjectTask> Tasks { get; set; } = [];
    }
}
