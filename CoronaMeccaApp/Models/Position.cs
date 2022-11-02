using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.Models
{
    public class Position
    {

        public string name { get; set; }
        public int zone_id { get; set; }
        public Zone zone { get; set; }


    }
}
