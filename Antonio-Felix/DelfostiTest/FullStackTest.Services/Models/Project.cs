﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackTest.Services.Models
{
    [Table(nameof(Project), Schema = "dbo")]
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public virtual List<ProjectTask> Tasks { get; set; }
    }
}
