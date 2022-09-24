using API.Dtos;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.SeedDataHelper
{
  static public class CourseSeedData
  {
    static public void SeedCourseData(this ModelBuilder builder, params CourseSeedDataDto[] seedDataArray)
    {
      foreach (var seedData in seedDataArray)
      {
        var courseSeedData = new Course
        {
          Id = Guid.NewGuid().ToString(),
          Name = seedData.CourseName
        };
        builder.Entity<Course>().HasData(courseSeedData);

        foreach (var section in seedData.Sections)
        {
          var sectionSeedData = new Section
          {
            Id = Guid.NewGuid().ToString(),
            Name = section.SectionName,
            CourseId = courseSeedData.Id
          };
          builder.Entity<Section>().HasData(sectionSeedData);

          var lessonsSeedData = new List<Lesson>();
          for (int i = 0; i < section.LessonNumber; i++)
          {
            lessonsSeedData.Add(new Lesson
            {
              Id = Guid.NewGuid().ToString(),
              Name = $"{section.SectionName}: Lesson {i + 1}",
              SectionId = sectionSeedData.Id
            });
          }
          builder.Entity<Lesson>().HasData(lessonsSeedData);
        }
      }
    }
  }
}
