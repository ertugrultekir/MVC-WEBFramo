using Framo.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Entities
{
    public class Slider : CoreEntity
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string ImagePath { get; set; }
        public string NavigateUrl { get; set; }

        public Guid UserID { get; set; }
        public virtual User User { get; set; }
    }
}
