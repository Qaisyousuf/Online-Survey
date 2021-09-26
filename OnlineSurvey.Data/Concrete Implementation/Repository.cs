using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public abstract class Repository<TModel>:IRepository<TModel> where TModel:class
    {
        protected ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TModel entity)
        {
            _context.Set<TModel>().Add(entity);
        }

        public IQueryable<TModel> GetAll()
        {
            var data = _context.Set<TModel>();
            return data;
        }

        public IQueryable<TModel> GetAll(params string[] navigationProperties)
        {
            IQueryable<TModel> data = _context.Set<TModel>().AsQueryable();

            foreach (string navigationproperty in navigationProperties)
            {
                data = data.Include(navigationproperty);
            }

            return data;
        }

        public TModel GetById(object id)
        {
            return _context.Set<TModel>().Find(id);
        }

        public void Remove(TModel entity)
        {
            _context.Set<TModel>().Remove(entity);
        }

        public void RemoveById(object id)
        {
            TModel model = GetById(id);
            if (model != null)
                Remove(model);
        }

        public void Update(TModel entity)
        {
            _context.Entry(entity).State =EntityState.Modified;
        }
    }
}
