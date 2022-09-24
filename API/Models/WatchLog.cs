using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
  public class WatchLog
  {
    public string Id { get; set; }
    public string CourseId { get; set; }
    public string LessonId { get; set; }
    public Lesson Lesson { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int PercentageWatched { get; set; }
  }
}
