using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations
{
  public class WatchLogConfig : IEntityTypeConfiguration<WatchLog>
  {
    public void Configure(EntityTypeBuilder<WatchLog> builder)
    {
      builder.Property(w => w.UserId).IsRequired(false);
      builder.Property(w => w.Id).ValueGeneratedOnAdd();
    }
  }
}
