using Framo.Core.Entity;
using Framo.Model.Entities;
using Framo.Model.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Framo.Model.Context
{
    public class FramoContext : DbContext
    {
        public FramoContext()
        {
            Database.Connection.ConnectionString = "Server=.; Database=FramoNtierDB; UID=sa; PWD=123";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new MovieMap());
            modelBuilder.Configurations.Add(new SliderMap());
            modelBuilder.Configurations.Add(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string ip = HttpContext.Current.Request.UserHostAddress;
            DateTime dt = DateTime.Now;
            string machineName = WindowsIdentity.GetCurrent().Name;

            foreach (var item in modifiedEntities)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = dt;
                            entity.CreatedIP = ip;
                            entity.CreatedComputerName = machineName;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedIP = ip;
                            entity.ModifiedDate = dt;
                            entity.ModifiedComputerName = machineName;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
