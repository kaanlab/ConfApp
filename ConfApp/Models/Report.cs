using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime ReportDate { get; set; }
        public string VideoUrl { get; set; }

        //
        public Conference Conference { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
    }
}
