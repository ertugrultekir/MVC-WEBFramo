using Framo.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Entities
{
    public class User : CoreEntity
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçersiz mail adresi girişi")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Password { get; set; }

        public virtual List<Movie> Movies { get; set; }
        public virtual List<Slider> Sliders { get; set; }
    }
}
