namespace API.Dtos
{
  public class CourseDetailsByLessonDto
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string VideoUrl { get; set; }
    public CourseDto Course { get; set; }
  }

  public class CourseDto
  {
    public string Name { get; set; }
    public List<SectionDto> Sections { get; set; } = new List<SectionDto>();
  }

  public class SectionDto
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();
  }

  public class LessonDto
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public bool IsCompleted { get; set; }
  }
}
