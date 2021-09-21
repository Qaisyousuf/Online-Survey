﻿using OnlineSurvey.Data.Interfaces;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        public ApplicationDbContext Context { get; }
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