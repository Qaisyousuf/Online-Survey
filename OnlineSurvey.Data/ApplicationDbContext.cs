using Microsoft.AspNet.Identity.EntityFramework;
using OnlineSurvey.Data.FluentAPI;
using OnlineSurvey.Model;
using System;
using System.Data.Entity;

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
        public DbSet<TwitterMetaTag> TwitterMetaTags { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<FooterLinks> FooterLinks { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<SurveyCatagory> SurveyCatagories { get; set; }
        public DbSet<UserSurveyRegistration> UserSurveyRegistrations { get; set; }
        public DbSet<UserGender> UserGenders { get; set; }
        public DbSet<MultipleChoiceQuestions> MultipleChoiceQuestions { get; set; }
        public DbSet<YesNoQuestion> YesNoQuestions { get; set; }
        public DbSet<TagQuestion> TagQuestions { get; set; }
        public DbSet<NumberQuestion> NumberQuestions { get; set; }
        public DbSet<MultiLineText> MultiLineTexts { get; set; }
        public DbSet<Survey> Surveys { get; set; } 
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SiteSettingMapping());
            modelBuilder.Configurations.Add(new SurveyAndMultipleChoiceAnswerMapping());
            modelBuilder.Configurations.Add(new MultipleChoiceQuestionMapping());
            modelBuilder.Configurations.Add(new ResponseMapping());
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnName("datetime2"));
                     
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
