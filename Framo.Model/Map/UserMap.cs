using Framo.Core.Map;
using Framo.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Map
{
    public class UserMap : CoreMap<User>
    {
        public UserMap()
        {
            ToTable("Users");
            Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired();
            Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired();
            Property(x => x.EmailAddress).HasColumnName("EmailAddress").HasMaxLength(100).IsRequired();
            Property(x => x.Password).HasColumnName("Password").HasMaxLength(100).IsRequired();
        }
    }
}
