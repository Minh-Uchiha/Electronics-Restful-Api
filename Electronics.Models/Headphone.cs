using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Models
{
    public class Headphone : Electronics
    {
        public string Color { get; set; }
        public string connectivityTech { get; set; }
        public double BatteryLife { get; set; }
        public int PhoneId { get; set; }
        public int LaptopId { get; set; }
    }
}
