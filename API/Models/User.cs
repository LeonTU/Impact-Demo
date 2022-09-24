using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
  public class User
  {
    public string Id { get; set; }
    public string FullName { get; set; } = String.Empty;
    public string ImageUrl { get; set; } = String.Empty;
    public List<WatchLog> WatchLogs { get; set; } = new List<WatchLog>();
  }
}
