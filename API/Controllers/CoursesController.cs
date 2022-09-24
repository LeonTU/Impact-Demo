using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.SeedDataHelper;
using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CoursesController : ControllerBase
  {
    private readonly ICourseRepository _repo;
    public CoursesController(ICourseRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("lesson/{id}")]
    public async Task<ActionResult<CourseDetailsByLessonDto>> Get(string id)
    {
      var lesson = await this._repo.GetLessonById(id, true);
      if (lesson == null)
      {
        return NotFound();
      }

      var course = await _repo.GetFullCourseDetailsById(lesson.Section.CourseId);
      if (course == null)
      {
        return NotFound();
      }

      var responseDto = new CourseDetailsByLessonDto
      {
        Id = lesson.Id,
        Name = lesson.Name,
        VideoUrl = lesson.VideoUrl,
        Course = new CourseDto
        {
          Name = course.Name,
          Sections = new List<SectionDto>(course.Sections.Select(s =>
          {
            return new SectionDto
            {
              Id = s.Id,
              Name = s.Name,
              Order = s.Order,
              Lessons = new List<LessonDto>(s.Lessons.Select(l =>
              {
                return new LessonDto
                {
                  Id = l.Id,
                  Name = l.Name,
                  Order = l.Order,
                  IsCompleted = IsLessonCompleted(l)
                };
              }))
            };
          }))
        }
      };

      return Ok(responseDto);
    }

    [HttpPost("watchlog/{id}")]
    public async Task<ActionResult> CreateWatchLog(string id, int pw)
    {
      if (pw < 0 || pw > 100)
      {
        return BadRequest();
      }

      var result = await _repo.CreateWatchLog(id, pw);
      if (result)
        return NoContent();
      else
        return BadRequest();
    }

    private bool IsLessonCompleted(Lesson lesson)
    {
      return lesson.WatchLogs.Any() ? lesson.WatchLogs.Max(w => w.PercentageWatched) == 100 : false;
    }
  }
}
