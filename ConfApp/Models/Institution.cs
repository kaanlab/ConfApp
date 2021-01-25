using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Models
{
    public class Institution
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }

        IEnumerable<Speaker> Speakers { get; set; }
    }
}
