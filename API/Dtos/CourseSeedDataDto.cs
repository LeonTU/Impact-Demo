using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
  public class CourseSeedDataDto
  {
    public string CourseName { get; set; }
    public SectionSeedDataDto[] Sections { get; set; }
  }

  public class SectionSeedDataDto
  {
    public string SectionName { get; set; }
    public int LessonNumber { get; set; }
  }
}
