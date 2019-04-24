using Domain.Entity;
using System.Collections.Generic;

namespace Domain.Contract
{
    public interface IDomainActions
    {
        int Insert<TEntity>(TEntity entity) where TEntity : BaseEntity;
        int InsertList<TEntity>(IList<TEntity> entity) where TEntity : BaseEntity;
        bool Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        bool Delete<TEntity>(int id) where TEntity : BaseEntity;
        bool DeleteAll<TEntity>() where TEntity : BaseEntity;
        IList<TEntity> GetAll<TEntity>() where TEntity : BaseEntity;
        IList<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;
        bool Commit();
    }
}