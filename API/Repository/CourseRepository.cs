using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
  public class CourseRepository : ICourseRepository
  {
    private readonly PostgresDbContext _context;

    public CourseRepository(PostgresDbContext context)
    {
      _context = context;
    }

    public async Task<bool> CreateWatchLog(string lessonId, int percentageWatched, string userId)
    {
      var lesson = await _context.Lessons
        .Include(l => l.Section)
        .FirstOrDefaultAsync(l => l.Id == lessonId);

      if (lesson == null)
      {
        return false;
      }

      var watchLog = new WatchLog
      {
        CourseId = lesson.Section.CourseId,
        LessonId = lessonId,
        UserId = userId,
        PercentageWatched = percentageWatched
      };
      _context.WatchLogs.Add(watchLog);

      try
      {
        return await _context.SaveChangesAsync() > 0;
      }
      catch (System.Exception)
      {
        return false;
      }
    }

    public async Task<Lesson> GetLessonById(string id, bool includeSection, bool includeCourse)
    {
      if (includeSection && !includeCourse)
      {
        return await _context.Lessons
          .Include(l => l.Section)
          .FirstOrDefaultAsync(l => l.Id == id);
      }

      if (includeCourse && includeCourse)
      {
        return await _context.Lessons
          .Include(l => l.Section)
          .ThenInclude(s => s.Course)
          .FirstOrDefaultAsync(l => l.Id == id);
      }

      return await _context.Lessons.FirstOrDefaultAsync((l => l.Id == id));
    }

    public async Task<Course> GetFullCourseDetailsById(string id)
    {
      var course = await _context.Courses
        .Include(c => c.Sections)
        .ThenInclude(s => s.Lessons)
        .ThenInclude(l => l.WatchLogs)
        .FirstOrDefaultAsync(c => c.Id == id);

      return course;
    }
  }
}
