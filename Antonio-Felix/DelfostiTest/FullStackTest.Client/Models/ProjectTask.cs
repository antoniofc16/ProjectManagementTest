using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.Models
{
    public class ProjectTask
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("projectId")]
        public Guid ProjectId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("statusId")]
        public Guid StatusId { get; set; }
        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }
        [JsonPropertyName("modifiedOn")]
        public DateTime? ModifiedOn { get; set; }
        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }
        [JsonPropertyName("project")]
        public virtual Project Project { get; set; }
        [JsonPropertyName("status")]
        public virtual TaskStatus Status { get; set; }
    }
}
