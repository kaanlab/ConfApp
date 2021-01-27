using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Models
{
    public class Institution
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 8 символов")]
        [MinLength(8)]
        public string Name { get; set; }

        IEnumerable<Speaker> Speakers { get; set; }
    }
}
