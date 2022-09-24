using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Configurations;
using API.Data.SeedDataHelper;
using API.Dtos;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class PostgresDbContext : DbContext
  {
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WatchLog> WatchLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new CourseConfig());
      modelBuilder.ApplyConfiguration(new SectionConfig());
      modelBuilder.ApplyConfiguration(new LessonConfig());
      modelBuilder.ApplyConfiguration(new WatchLogConfig());

      CourseSeedDataDto seedDataAngular = new CourseSeedDataDto
      {
        CourseName = "Angular",
        Sections = new[] {
          new SectionSeedDataDto {SectionName = "Routing", LessonNumber = 10},
          new SectionSeedDataDto {SectionName = "Service", LessonNumber = 20},
          new SectionSeedDataDto {SectionName = "Directive", LessonNumber = 5}
        }
      };

      CourseSeedDataDto seedDataDotNet = new CourseSeedDataDto
      {
        CourseName = "DotNet",
        Sections = new[] {
          new SectionSeedDataDto {SectionName = "MVC", LessonNumber = 10},
          new SectionSeedDataDto {SectionName = "Entity Framework", LessonNumber = 20},
          new SectionSeedDataDto {SectionName = "Web API", LessonNumber = 10}
        }
      };

      modelBuilder.SeedCourseData(seedDataAngular, seedDataDotNet);

      modelBuilder.Entity<User>().HasData(new User
      {
        Id = Guid.NewGuid().ToString(),
        FullName = "Leon"
      });
    }
  }
}
