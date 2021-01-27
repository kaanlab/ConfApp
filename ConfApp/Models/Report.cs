using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Models
{
    public class Report
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string Topic { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public DateTime ReportDate { get; set; }
        public string VideoUrl { get; set; }

        //
        public Conference Conference { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
    }
}
