using System;

namespace OnlineSurvey.Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ApplicationDbContext Context { get; }

        IBannerRepository BannerRepository { get; }
        IMetaTagRepository MetaTagRepository { get; }

        void Commit();
    }
}
