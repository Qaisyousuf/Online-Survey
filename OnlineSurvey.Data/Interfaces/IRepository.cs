using System.Linq;

namespace OnlineSurvey.Data.Interfaces
{
    public interface IRepository<TModel> where TModel:class 
    {
        void Add(TModel entity);
        void Update(TModel entity);
        IQueryable<TModel> GetAll();
        TModel GetById(object id);
        void Remove(TModel entity);
        void RemoveById(object id);

        IQueryable<TModel> GetAll(params string[] navigationProperties);
    }
}
