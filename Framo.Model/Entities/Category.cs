using Framo.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Entities
{
    public class Category : CoreEntity
    {
        [Required(ErrorMessage ="Bu alan boş bırakılamaz.")]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}
