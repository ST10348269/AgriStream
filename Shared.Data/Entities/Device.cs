using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "Idle";
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
