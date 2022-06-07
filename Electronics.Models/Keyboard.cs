using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Models
{
    public class Keyboard : Electronics
    {
        public string Type { get; set; }
        public string Switch { get; set; }
        public bool HasRGB { get; set; }
        public string ConnectivityTech { get; set; }
        public bool HasBackLit { get; set; }
        public string Color { get; set; }
        public int LaptopId { get; set; }
    }
}
