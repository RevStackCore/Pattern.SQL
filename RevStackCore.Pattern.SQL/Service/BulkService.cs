using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RevStackCore.Pattern.SQL.Service
{
    public class BulkService<TEntity, TKey> : IBulkService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly IBulkRepository<TEntity, TKey> _repository;
        public BulkService(IBulkRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            return Task.FromResult(Add(entity));
        }

        public void BulkInsert(IEnumerable<TEntity> entities)
        {
            _repository.BulkInsert(entities);
        }

        public Task BulkInsertAsync(IEnumerable<TEntity> entities)
        {
            BulkInsert(entities);
            return Task.CompletedTask;
        }

        public void BulkUpdate(IEnumerable<TEntity> entities)
        {
            _repository.BulkUpdate(entities);
        }

        public Task BulkUpdateAsync(IEnumerable<TEntity> entities)
        {
            BulkUpdate(entities);
            return Task.CompletedTask;
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            return Task.Run(() => Delete(entity));
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Find(predicate));
        }

        public IEnumerable<TEntity> Get()
        {
            return _repository.Get();
        }

        public Task<IEnumerable<TEntity>> GetAsync()
        {
            return Task.FromResult(Get());
        }

        public TEntity GetById(TKey id)
        {
            return _repository.GetById(id);
        }

        public Task<TEntity> GetByIdAsync(TKey id)
        {
            return Task.FromResult(GetById(id));
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        public IDbConnection Db
        {
            get
            {
                return _repository.Db;
            }
        }
    }
}
