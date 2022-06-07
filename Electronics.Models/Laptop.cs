using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Models
{
    public class Laptop : Electronics
    {
        public double Size { get; set; } 
        public double RamSize { get; set; }
        public double SSD { get; set; }
        public double HDD { get; set; }
        public int MonitorSpeed { get; set; }
        public int BatteryLife { get; set; }
        public string CPU { get; set; }
        public ICollection<Headphone> CompatibleHeadphones { get; set; } = new List<Headphone>();
        public ICollection<Keyboard> CompatibleKeyboards { get; set; } = new List<Keyboard>();
    }
}
