using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
  public class Section
  {
    public string Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Order { get; set; }
    public string CourseId { get; set; }
    public Course Course { get; set; }
    public List<Lesson> Lessons { get; set; }
  }
}
