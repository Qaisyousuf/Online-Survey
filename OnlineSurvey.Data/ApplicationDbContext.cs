using Microsoft.AspNet.Identity.EntityFramework;
using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("OnlineSurvey", throwIfV1Schema: false)
        {
        }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<MetaTag> metaTags { get; set; }
        public DbSet<OpenGraphMetaTag> OpenGraphMetaTags { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
