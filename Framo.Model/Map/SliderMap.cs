using Framo.Core.Map;
using Framo.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Model.Map
{
    public class SliderMap : CoreMap<Slider>
    {
        public SliderMap()
        {
            ToTable("Sliders");
            Property(x => x.Title).HasColumnName("Title").HasMaxLength(250).IsRequired();
            Property(x => x.Description).HasColumnName("Description").HasMaxLength(250).IsOptional();
            Property(x => x.ImagePath).HasColumnName("ImagePath").HasMaxLength(250).IsOptional();
            Property(x => x.NavigateUrl).HasColumnName("NavigateUrl").HasMaxLength(250).IsOptional();
        }
    }
}
