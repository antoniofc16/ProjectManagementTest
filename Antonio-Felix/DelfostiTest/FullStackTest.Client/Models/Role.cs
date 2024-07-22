using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.Models
{
    public class Role
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
