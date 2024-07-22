using FullStackTest.Client.Models;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.ViewModels
{
    public class SaveTaskResponse : ResponseModel
    {
        [JsonPropertyName("tasks")]
        public List<ProjectTask> Tasks { get; set; } = [];
    }
}
