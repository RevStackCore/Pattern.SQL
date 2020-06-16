using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RevStackCore.Pattern.SQL
{
    public interface IBulkService<TEntity, TKey> : IService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        int BulkInsert(IEnumerable<TEntity> entities);
        int BulkUpdate(IEnumerable<TEntity> entities);
        int BulkDelete();
        Task<int> BulkInsertAsync(IEnumerable<TEntity> entities);
        Task<int> BulkUpdateAsync(IEnumerable<TEntity> entities);
        Task<int> BulkDeleteAsync();
        IDbConnection Db { get; }
    }
}
