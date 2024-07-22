using FullStackTest.Client.Models;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.ViewModels
{
    public class SaveProjectResponse : ResponseModel
    {
        [JsonPropertyName("projects")]
        public List<Project> Projects { get; set; } = [];
    }
}
