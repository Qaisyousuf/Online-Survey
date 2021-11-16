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
        ISurveyCatagoryRepository SurveyCatagoryRepository { get; }
        IGenderRepository GenderRepository { get;  }
        IUserSurveyRepository UserSurveyRepository { get; }
        IMultipleChoiceQuestionsRepository MultipleChoiceQuestionsRepository { get; }
        IYesNoAnswerRepository YesNoAnswerRepository { get; }
        ITagQuestionRepository TagQuestionRepository { get; }
        INumberQuestionRepository NumberQuestionRepository { get; }
        IMultiLineTextRepository MultiLineTextRepository { get; }
        ISurveyRepository SurveyRepository { get; }
        IQuesiotnRepository QuesiotnRepository { get; }
        IResponseRepository ResponseRepository { get; }
        IMultiLineTextResponseRepository MultiLineResponseRepository { get;} 
        IMultiLineTextAnswerRepository MultiLineTextAnswerRepository { get; }
        IYesNoQuestionRepository YesNoQuestionRepository { get; }
        ICheckBoxAnswerRepository CheckBoxAnswerRepository { get; }
        ICheckBoxQuestionRepository CheckBoxQuestionRepository { get; }

      

        void Commit();
    }
}
