using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Interface
{
  public interface ICourseRepository
  {
    Task<bool> CreateWatchLog(string lessonId, int percentageWatched, string userId);
    Task<Lesson> GetLessonById(string id, bool includeSection = false, bool includeCourse = false);
    Task<Course> GetFullCourseDetailsById(string id);
    Task<List<SimpleLessonDto>> GetLessonList();
  }
}
