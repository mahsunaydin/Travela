using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Context
{
    public class TravelaContext: IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=MAHSUNAYDIN\SQLEXPRESS; initial Catalog=TravelaDb; integrated Security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<UIAbout> UIAbouts { get; set; }
        public DbSet<UIFeature> UIFeatures { get; set; }
        public DbSet<UIService> UIServices { get; set; }
        public DbSet<UICarousel> UICarousels { get; set; }
        public DbSet<UIAboutFeature> UIAboutFeatures { get; set; }
        public DbSet<UIGuide> UIGuides { get; set; }
        public DbSet<UITestimonial> UITestimonials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PageHeaderDeatil> PageHeaderDetails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
