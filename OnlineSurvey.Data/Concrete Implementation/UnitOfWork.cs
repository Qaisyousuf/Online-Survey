using OnlineSurvey.Data.Interfaces;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        public IBannerRepository BannerRepository => new BannerRepository(Context);

        public IMetaTagRepository MetaTagRepository => new MetaTagRepository(Context);

        public IOGMetaTagRepository OGMetaTagRepository => new OGMetaTagRepository(Context);

        public ITwitterMetaTagRepository TwitterMetaTagRepository => new TwitterMetaTagRepository(Context);

        public IFooterLinksRepository FooterLinksRepository => new FooterLinksRepository(Context);

        public ISiteSettingsRepository SiteSettingsRepository => new SiteSettingsRepository(Context);

        public IMenuRepository MenuRepository => new MenuRepository(Context);

        public IPageRepository PageRepository => new PageRepository(Context);

        public ISurveyCatagoryRepository SurveyCatagoryRepository => new SurveyCatagoryRepository(Context);

        public IGenderRepository GenderRepository => new GenderRepository(Context);

        public UnitOfWork()
        {
            Context = new ApplicationDbContext();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    } 
}
