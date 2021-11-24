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

        public IUserSurveyRepository UserSurveyRepository => new UserSurveyRepository(Context);

        public IMultipleChoiceQuestionsRepository MultipleChoiceQuestionsRepository => new MultipleChoiceQuestionsRepository(Context);

       

        public ITagQuestionRepository TagQuestionRepository => new TagQuestionRepository(Context);

        public INumberQuestionRepository NumberQuestionRepository => new NumberQuestionRepository(Context);

        public IMultiLineTextRepository MultiLineTextRepository => new MultiLineTextRepository(Context);

        public ISurveyRepository SurveyRepository => new SurveyRepository(Context);

        public IQuesiotnRepository QuesiotnRepository => new QuesiotnRepository(Context);

        public IResponseRepository ResponseRepository => new ResponseRepository(Context);

        public IMultiLineTextResponseRepository MultiLineResponseRepository => new MultiLineTextResponseRepository(Context);

        public IMultiLineTextAnswerRepository MultiLineTextAnswerRepository =>new MultiLineTextAnswerRepository(Context);

        public IYesNoAnswerRepository YesNoAnswerRepository => new YesNoAnswerRepository(Context);

        public IYesNoQuestionRepository YesNoQuestionRepository => new YesNoQuestionRepository(Context);

        public ICheckBoxAnswerRepository CheckBoxAnswerRepository => new CheckBoxAnswerRepository(Context);

        public ICheckBoxQuestionRepository CheckBoxQuestionRepository => new CheckBoxQuestionRepository(Context);

        public IUserDashboardRepository UserDashboardRepository => new UserDashboardRepository(Context);

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
