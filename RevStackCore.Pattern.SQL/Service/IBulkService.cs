using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RevStackCore.Pattern.SQL
{
    public interface IBulkService<TEntity, TKey> : IService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        void BulkInsert(IEnumerable<TEntity> entities);
        void BulkUpdate(IEnumerable<TEntity> entities);
        Task BulkInsertAsync(IEnumerable<TEntity> entities);
        Task BulkUpdateAsync(IEnumerable<TEntity> entities);
        IDbConnection Db { get; }
    }
}
