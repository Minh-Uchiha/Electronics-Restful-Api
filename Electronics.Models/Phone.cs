using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Models
{
    public class Phone : Electronics
    {
        public double Size { get; set; }
        public double RamSize { get; set; }
        public string Screen { get; set; }
        public int BatteryLife { get; set; }
        public string Camera { get; set; }
        public string Chip { get; set; }
        public ICollection<Headphone> CompatibleHeadphones { get; set; } = new List<Headphone>();
    }
}
