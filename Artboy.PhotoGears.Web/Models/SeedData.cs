using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Artboy.PhotoGears.Web.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            PhotoGearsDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<PhotoGearsDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (context.Mounts.Count() == 0)
            {
                context.Mounts.AddRange(

                    new Mount
                    {
                        Name = "None",
                        FlangeFocalDistance = 0.00m,
                        ThreadDiameter = null,
                        MountType = MountTypeEnum.Fixed
                    },
                    new Mount
                    {
                        Name = "Canon EX",
                        FlangeFocalDistance = 20.00m,
                        ThreadDiameter = null,
                        MountType = MountTypeEnum.Bayonet
                    }, new Mount
                    {
                        Name = "Canon FL/FD",
                        FlangeFocalDistance = 42.00m,
                        ThreadDiameter = 48.00m,
                        MountType = MountTypeEnum.BreechLock
                    },
                     new Mount
                     {
                         Name = "Canon EF",
                         FlangeFocalDistance = 44.00m,
                         ThreadDiameter = 54.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Canon EF-M",
                         FlangeFocalDistance = 18.00m,
                         ThreadDiameter = 47.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Canon EOS-R",
                         FlangeFocalDistance = 20.00m,
                         ThreadDiameter = 54.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Nikon S",
                         FlangeFocalDistance = 34.85m,
                         ThreadDiameter = 49.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Nikon F",
                         FlangeFocalDistance = 46.50m,
                         ThreadDiameter = 44.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Nikon 1",
                         FlangeFocalDistance = 17.00m,
                         ThreadDiameter = 40.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Nikon Z",
                         FlangeFocalDistance = 16.00m,
                         ThreadDiameter = 55.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Sony Mavica",
                         FlangeFocalDistance = 57.00m,
                         ThreadDiameter = null,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Sony E",
                         FlangeFocalDistance = 18.00m,
                         ThreadDiameter = 46.10m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Minolta SR",
                         FlangeFocalDistance = 43.50m,
                         ThreadDiameter = 44.97m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Minolta V",
                         FlangeFocalDistance = 38.00m,
                         ThreadDiameter = 39.70m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Minolta A",
                         FlangeFocalDistance = 44.50m,
                         ThreadDiameter = 49.70m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Pentax Auto 110",
                         FlangeFocalDistance = 27.00m,
                         ThreadDiameter = null,
                         MountType = MountTypeEnum.Bayonet
                     }, new Mount
                     {
                         Name = "Pentax Q",
                         FlangeFocalDistance = 9.20m,
                         ThreadDiameter = 31.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Pentax K",
                         FlangeFocalDistance = 45.46m,
                         ThreadDiameter = 44.00m,
                         MountType = MountTypeEnum.Bayonet
                     },
                     new Mount
                     {
                         Name = "Leitz Visoflex I",
                         FlangeFocalDistance = 91.30m,
                         ThreadDiameter = 39.00m,
                         MountType = MountTypeEnum.Screw
                     },
                       new Mount
                       {
                           Name = "Leitz Visoflex II/III",
                           FlangeFocalDistance = 40.00m,
                           ThreadDiameter = 44.00m,
                           MountType = MountTypeEnum.Bayonet
                       },
                         new Mount
                         {
                             Name = "Leica M",
                             FlangeFocalDistance = 27.80m,
                             ThreadDiameter = 44.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                          new Mount
                          {
                              Name = "Leica R",
                              FlangeFocalDistance = 47.00m,
                              ThreadDiameter = 49.00m,
                              MountType = MountTypeEnum.Bayonet
                          },
                           new Mount
                           {
                               Name = "Leica L",
                               FlangeFocalDistance = 20.00m,
                               ThreadDiameter = 51.60m,
                               MountType = MountTypeEnum.Bayonet
                           },
                            new Mount
                            {
                                Name = "Contax RF",
                                FlangeFocalDistance = 34.85m,
                                ThreadDiameter = 44.00m,
                                MountType = MountTypeEnum.DoubleBayonet
                            },
                             new Mount
                             {
                                 Name = "Contax G",
                                 FlangeFocalDistance = 29.00m,
                                 ThreadDiameter = 44.00m,
                                 MountType = MountTypeEnum.BreechLock
                             },
                            new Mount
                            {
                                Name = "Contax N",
                                FlangeFocalDistance = 48.00m,
                                ThreadDiameter = 55.00m,
                                MountType = MountTypeEnum.Bayonet
                            },
                         new Mount
                         {
                             Name = "Contax/Yashica",
                             FlangeFocalDistance = 45.50m,
                             ThreadDiameter = 48.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                          new Mount
                          {
                              Name = "Yashica MA",
                              FlangeFocalDistance = 45.80m,
                              ThreadDiameter = null,
                              MountType = MountTypeEnum.Bayonet
                          },
                          new Mount
                          {
                              Name = "Fujica X",
                              FlangeFocalDistance = 43.50m,
                              ThreadDiameter = 49.00m,
                              MountType = MountTypeEnum.Bayonet
                          },
                         new Mount
                         {
                             Name = "Fujifilm X",
                             FlangeFocalDistance = 17.70m,
                             ThreadDiameter = 44.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Olympus Pen F",
                             FlangeFocalDistance = 28.95m,
                             ThreadDiameter = null,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Olympus OM",
                             FlangeFocalDistance = 46.00m,
                             ThreadDiameter = 46.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Four Thirds",
                             FlangeFocalDistance = 38.67m,
                             ThreadDiameter = 44.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Micro Four Thirds",
                             FlangeFocalDistance = 19.25m,
                             ThreadDiameter = 38.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Konica M",
                             FlangeFocalDistance = 27.80m,
                             ThreadDiameter = 44.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Konica F",
                             FlangeFocalDistance = 40.5m,
                             ThreadDiameter = 40.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Konica AR",
                             FlangeFocalDistance = 40.50m,
                             ThreadDiameter = 47.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Samsung NX",
                             FlangeFocalDistance = 25.50m,
                             ThreadDiameter = 42.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Icarex BM",
                             FlangeFocalDistance = 48.00m,
                             ThreadDiameter = null,
                             MountType = MountTypeEnum.BreechLock
                         },
                         new Mount
                         {
                             Name = "D",
                             FlangeFocalDistance = 12.29m,
                             ThreadDiameter = 15.880m,
                             MountType = MountTypeEnum.Screw
                         },
                         new Mount
                         {
                             Name = "CS",
                             FlangeFocalDistance = 12.256m,
                             ThreadDiameter = 25.40m,
                             MountType = MountTypeEnum.Screw
                         },
                         new Mount
                         {
                             Name = "C",
                             FlangeFocalDistance = 17.526m,
                             ThreadDiameter = 25.40m,
                             MountType = MountTypeEnum.Screw
                         },
                         new Mount
                         {
                             Name = "Bolex Bajonet",
                             FlangeFocalDistance = 23.22m,
                             ThreadDiameter = null,
                             MountType = MountTypeEnum.BreechLock
                         },
                         new Mount
                         {
                             Name = "Leica M39",
                             FlangeFocalDistance = 28.80m,
                             ThreadDiameter = 39.00m,
                             MountType = MountTypeEnum.Screw
                         },
                         new Mount
                         {
                             Name = "Alpa",
                             FlangeFocalDistance = 37.80m,
                             ThreadDiameter = 42.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Miranda M44",
                             FlangeFocalDistance = 41.50m,
                             ThreadDiameter = null,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Petriflex",
                             FlangeFocalDistance = 43.50m,
                             ThreadDiameter = null,
                             MountType = MountTypeEnum.BreechLock
                         },
                         new Mount
                         {
                             Name = "Sigma SA",
                             FlangeFocalDistance = 44.00m,
                             ThreadDiameter = null,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Paxette",
                             FlangeFocalDistance = 44.00m,
                             ThreadDiameter = 39.00m,
                             MountType = MountTypeEnum.Screw
                         },
                         new Mount
                         {
                             Name = "Praktiflex",
                             FlangeFocalDistance = 44.00m,
                             ThreadDiameter = 40.00m,
                             MountType = MountTypeEnum.Screw
                         },
                         new Mount
                         {
                             Name = "Praktica",
                             FlangeFocalDistance = 44.40m,
                             ThreadDiameter = 42.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Exakta/Topcon RE",
                             FlangeFocalDistance = 44.70m,
                             ThreadDiameter = 46.00m,
                             MountType = MountTypeEnum.Bayonet
                         },
                         new Mount
                         {
                             Name = "Zenit M39",
                             FlangeFocalDistance = 45.20m,
                             ThreadDiameter = 39.00m,
                             MountType = MountTypeEnum.Screw
                         },
                         new Mount
                         {
                             Name = "Asahiflex M37",
                             FlangeFocalDistance = 45.46m,
                             ThreadDiameter = 37.00m,
                             MountType = MountTypeEnum.Screw
                         },
                         new Mount
                         {
                             Name = "M42",
                             FlangeFocalDistance = 45.46m,
                             ThreadDiameter = 42.00m,
                             MountType = MountTypeEnum.Screw
                         }
                    ) ;
                
                context.SaveChanges();
            }
        }
    }
}
