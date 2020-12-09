using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Web.Models
{
    public class PhotoGearsDbContext : DbContext
    {
        public PhotoGearsDbContext(DbContextOptions<PhotoGearsDbContext> options)
            :base(options)
        { }

        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Lens> Lenses { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<GearImage> GearImages { get; set; }
        public DbSet<Mount> Mounts { get; set; }
    }
}
