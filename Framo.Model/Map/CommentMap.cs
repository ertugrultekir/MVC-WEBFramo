using Framo.Core.Map;
using Framo.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Map
{
    public class CommentMap : CoreMap<Comment>
    {
        public CommentMap()
        {
            ToTable("Comments");
            Property(x => x.CommentText).HasColumnName("CommentText").HasMaxLength(500).IsOptional();
            Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(500).IsOptional();
            Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(500).IsOptional();
            Property(x => x.EmailAddress).HasColumnName("EmailAddress").HasMaxLength(500).IsOptional();
        }
    }
}
