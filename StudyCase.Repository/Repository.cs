using Microsoft.EntityFrameworkCore;
using StudyCase.Application;
using System.Collections.Generic;

namespace StudyCase.Repository
{
    public class Repository<T> : IRepository<T> where T :class
    {
        
        private readonly DbContext _studyDbContext;
        private DbSet<T> _table;

        public Repository(DbContext studyDbContext)
        {
            _studyDbContext = studyDbContext;
            _table = _studyDbContext.Set<T>();
        }

        public T Insert(T entity)
        {
            _table.Add(entity);
            _studyDbContext.SaveChanges();
            return entity;
        }
        public void AddRange(IEnumerable<T> entity)
        {
            _table.AddRange(entity);
            _studyDbContext.SaveChanges();
        }

    }
}
