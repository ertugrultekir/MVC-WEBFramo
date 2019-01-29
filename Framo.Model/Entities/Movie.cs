using Framo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Entities
{
    public class Movie : CoreEntity
    {
        public string Name { get; set; }
        public string Sypnosis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterPath { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public Guid UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
