using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskTest.DAL.EF;


namespace TaskTest.DAL.Repository.Impl
{
    public class RepositoryBaseImpl<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext;
        public RepositoryBaseImpl(ApplicationDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() =>
            RepositoryContext.Set<T>()
                .AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void CreateRange(IEnumerable<T> entity)
        {

            RepositoryContext.Set<T>().AddRange(entity);
        } 


        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}