using Framo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Entities
{
    public class Comment : CoreEntity
    {
        public string CommentText { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public Guid MovieID { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
