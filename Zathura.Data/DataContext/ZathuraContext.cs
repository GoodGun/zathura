using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zathura.Data.Model;

namespace Zathura.Data.DataContext
{
    public class ZathuraContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
    }
}
