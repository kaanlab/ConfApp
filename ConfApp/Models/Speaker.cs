using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 2 символов")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 2 символов")]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 4 символов")]
        [MinLength(4)]
        public string Position { get; set; }
        public string Photo { get; set; }

        //
        public Institution Institution { get; set; }
        public Report Report { get; set; }

    }
}
