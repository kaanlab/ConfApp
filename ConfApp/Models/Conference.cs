using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Models
{
    public class Conference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainTopic { get; set; }
        public string Topic { get; set; }
        public string Banner { get; set; }
        public string Logo { get; set; }


        IEnumerable<Report> Reports { get; set; }

    }
}
