using Microsoft.EntityFrameworkCore;
using static FullStackTest.Services.Commons.ProjectManagementCommons;

namespace FullStackTest.Services.Models.DbContexts
{
    public class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<TaskStatus> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasDefaultValueSql("NEWSEQUENTIALID()");

                entity.Property(e => e.CreatedOn)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasDefaultValueSql("NEWSEQUENTIALID()");

                entity.Property(e => e.CreatedOn)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasDefaultValueSql("NEWSEQUENTIALID()");

                entity.Property(e => e.CreatedOn)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasDefaultValueSql("NEWSEQUENTIALID()");

                entity.HasData(
                    new Role
                    {
                        Id = UserRoles.Admin,
                        Description = "Administrador"
                    },
                    new Role
                    {
                        Id = UserRoles.Consumer,
                        Description = "Consumidor"
                    }
                );
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasDefaultValueSql("NEWSEQUENTIALID()");
                entity.HasData(
                    new TaskStatus
                    {
                        Id = TaskStatuses.Pending,
                        Description = "Pendiente",
                    },
                    new TaskStatus
                    {
                        Id = TaskStatuses.InProcess,
                        Description = "En Progreso",
                    },
                    new TaskStatus
                    {
                        Id = TaskStatuses.Completed,
                        Description = "Completado",
                    }
                );
            });
        }
    }
}
