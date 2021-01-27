using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string Position { get; set; }
        public string Photo { get; set; }

        //
        public Institution Institution { get; set; }
        public IEnumerable<Report> Reports { get; set; }

    }
}
