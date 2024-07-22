using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackTest.Services.Models
{
    [Table(nameof(Role), Schema = "dbo")]
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
