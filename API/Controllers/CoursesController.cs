using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data.SeedDataHelper;
using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class CoursesController : ControllerBase
  {
    private readonly ICourseRepository _repo;
    public CoursesController(ICourseRepository repo)
    {
      _repo = repo;
    }

    [AllowAnonymous]
    [HttpGet("lesson")]
    public async Task<ActionResult> GetLessonList()
    {
      var lists = await _repo.GetLessonList();

      return Ok(lists);
    }

    [AllowAnonymous]
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

      var userId = GetUserId();

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
                  IsCompleted = IsLessonCompleted(l, userId)
                };
              }))
            };
          }))
        }
      };

      return Ok(responseDto);
    }

    [AllowAnonymous]
    [HttpPost("watchlog/{id}")]
    public async Task<ActionResult> CreateWatchLog(string id, int pw)
    {
      if (pw < 0 || pw > 100)
      {
        return BadRequest();
      }

      var result = await _repo.CreateWatchLog(id, pw, GetUserId());
      if (result)
        return NoContent();
      else
        return BadRequest();
    }

    private bool IsLessonCompleted(Lesson lesson, string userId)
    {
      if (!lesson.WatchLogs.Any())
      {
        return false;
      }

      if (userId == null)
      {
        return lesson.WatchLogs.Max(w => w.PercentageWatched) == 100;
      }
      else
      {
        return lesson.WatchLogs
          .Where(w => w.UserId == userId)
          .Max(w => w?.PercentageWatched) == 100;
      }
    }

    private string GetUserId()
    {
      return User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
    }
  }
}
