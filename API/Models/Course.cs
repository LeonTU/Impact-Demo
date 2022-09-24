using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
  public class Course
  {
    public string Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public List<Section> Sections { get; set; }
  }
}
