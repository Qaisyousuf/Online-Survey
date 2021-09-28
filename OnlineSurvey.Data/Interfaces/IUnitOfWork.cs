using System;

namespace OnlineSurvey.Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ApplicationDbContext Context { get; }

        IBannerRepository BannerRepository { get; }
        IMetaTagRepository MetaTagRepository { get; }
        IOGMetaTagRepository OGMetaTagRepository { get; }
        ITwitterMetaTagRepository TwitterMetaTagRepository { get; }
        IFooterLinksRepository FooterLinksRepository { get; }
        ISiteSettingsRepository SiteSettingsRepository { get; }
        IMenuRepository MenuRepository { get; }
        IPageRepository PageRepository { get; }

        void Commit();
    }
}
