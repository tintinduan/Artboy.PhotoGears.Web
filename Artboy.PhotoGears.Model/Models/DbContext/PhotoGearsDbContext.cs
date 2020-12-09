using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Artboy.PhotoGears.Models
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
public class PhotoGearsDbContextFactory : IDesignTimeDbContextFactory<PhotoGearsDbContext>
{
    PhotoGearsDbContext IDesignTimeDbContextFactory<PhotoGearsDbContext>.CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PhotoGearsDbContext>();
        optionsBuilder.UseSqlServer("Server=NEWDEVMASTER\\DEVMASTERSQL;Database=PhotoGears;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new PhotoGearsDbContext(optionsBuilder.Options);
    }
}
