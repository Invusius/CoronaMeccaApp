using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.Models
{
    public class Box
    {

        public int id { get; set; }
        public string name { get; set; }
        public string batch { get; set; }
        public Types type { get; set; }
        public Position position { get; set; }
        public string created_at { get; set; }
        public string expires_at { get; set; }

    }
}
