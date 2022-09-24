using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
  public class Lesson
  {
    public string Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string VideoUrl { get; set; } = String.Empty;
    public int Order { get; set; }
    public string SectionId { get; set; }
    public Section Section { get; set; }
    public List<WatchLog> WatchLogs { get; set; } = new List<WatchLog>();
  }
}
