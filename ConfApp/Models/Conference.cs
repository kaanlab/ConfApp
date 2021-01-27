using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Models
{
    public class Conference
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string MainTopic { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string Topic { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string Banner { get; set; }
        public string Logo { get; set; }

        //
        IEnumerable<Report> Reports { get; set; }
    }
}
