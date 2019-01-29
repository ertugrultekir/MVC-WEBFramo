using Framo.Core.Map;
using Framo.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Map
{
    public class CategoryMap : CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            Property(x => x.CategoryName).HasColumnName("CategoryName").HasMaxLength(100).IsRequired();
            Property(x => x.Description).HasColumnName("Description").HasMaxLength(250).IsOptional();
        }
    }
}
