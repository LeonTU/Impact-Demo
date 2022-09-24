using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations
{
  public class SectionConfig : IEntityTypeConfiguration<Section>
  {
    public void Configure(EntityTypeBuilder<Section> builder)
    {
      builder.Property(s => s.Name).HasMaxLength(250);
    }
  }
}
