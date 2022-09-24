using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations
{
  public class LessonConfig : IEntityTypeConfiguration<Lesson>
  {
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
      builder.Property(l => l.Name).HasMaxLength(250);
      builder.Property(l => l.VideoUrl).HasMaxLength(355);
    }
  }
}
