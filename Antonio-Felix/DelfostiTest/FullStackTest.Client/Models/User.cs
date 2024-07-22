using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonPropertyName("roleId")]
        public Guid RoleId { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }
        [JsonPropertyName("modifiedOn")]
        public DateTime? ModifiedOn { get; set; }
        [JsonPropertyName("role")]
        public virtual Role Role { get; set; }
    }
}
