using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackTest.Services.Models
{
    [Table(nameof(TaskStatus), Schema = "dbo")]
    public class TaskStatus
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
