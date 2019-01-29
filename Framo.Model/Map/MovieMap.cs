using Framo.Core.Map;
using Framo.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Map
{
    public class MovieMap : CoreMap<Movie>
    {
        public MovieMap()
        {
            ToTable("Movies");
            Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            Property(x => x.Sypnosis).HasColumnName("Sypnosis").HasMaxLength(200).IsOptional();
            Property(x => x.ReleaseDate).HasColumnName("ReleaseDate").HasColumnType("date").IsOptional();
            Property(x => x.PosterPath).HasColumnName("PosterPath").HasMaxLength(250).IsOptional();
        }
    }
}
