using System.Collections.Generic;
using System.Linq;
using Domain.Entity;

namespace Domain.Contract
{
    public class DomainActions : IDomainActions
    {
        private readonly DBContext _dbContext;

        public DomainActions(DBContext areiqContext)
        {
            _dbContext = areiqContext;
        }

        public bool Commit()
        {
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete<TEntity>(int id) where TEntity : BaseEntity
        {
            var entityToDelete = _dbContext.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
            if (entityToDelete == null) return false;

            _dbContext.Set<TEntity>().Remove(entityToDelete);
            return true;
        }

        public bool DeleteAll<TEntity>() where TEntity : BaseEntity
        {
            var all = _dbContext.Set<TEntity>();
            if(all != null && all.Count<TEntity>() > 0)
                _dbContext.Set<TEntity>().RemoveRange(all);

            return true;
        }

        public IList<TEntity> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public IList<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return _dbContext.Set<TEntity>().Where( x => x.Id == id).ToList();
        }
        // Expression<Func<TEntity, bool>> filterExpression
        public int Insert<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null) return -1;
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges(false);
        }

        public int InsertList<TEntity>(IList<TEntity> entity) where TEntity : BaseEntity
        {
            _dbContext.Set<TEntity>().AddRange(entity);

            return 1;
        }

        public bool Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new System.NotImplementedException();
        }
    }
}