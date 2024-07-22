using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FullStackTest.Services.Models
{
    [Table(nameof(User), Schema = "dbo")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}
