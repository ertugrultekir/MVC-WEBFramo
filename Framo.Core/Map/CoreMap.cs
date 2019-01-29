using Framo.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Core.Map
{
    //CoreMap işlemlerini (teknik olarak bu sınıf tüm sınıfların base class'ı olacağından dolayı) tüm sınıflar için yapmamız gerekmektedir. GenericType olarak gönderilen sınıf EntityTypeConfiguration'da da çalıştırılıyor. Bu işlemlerin sadece CoreEntity sınıfından türetilen sınıflar için yapılmasını istediğimizden where T : CoreEntity komutunu giriyoruz.
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            //CoreMap sınıfının yapıcı metodunda hangi CoreEntity sınıfındaki hangi propertylerin veritabanına hangi özelliklerle set edileceğini FluentAPI ile belirledik.
            Property(x => x.ID)
                .HasColumnName("ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime")
                .IsOptional();

            Property(x => x.CreatedIP)
                .HasColumnName("CreatedIP")
                .HasMaxLength(15)
                .IsOptional();

            Property(x => x.CreatedComputerName)
                .HasColumnName("CreatedComputerName")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .IsOptional();

            Property(x => x.ModifiedIP)
                .HasColumnName("ModifiedIP")
                .HasMaxLength(15)
                .IsOptional();

            Property(x => x.ModifiedComputerName)
                .HasColumnName("ModifiedComputerName")
                .HasMaxLength(100)
                .IsOptional();

        }
    }
}
