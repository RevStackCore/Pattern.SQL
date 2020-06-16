using System;
using System.Collections.Generic;
using System.Data;

namespace RevStackCore.Pattern.SQL
{
    public interface IBulkRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        int BulkInsert(IEnumerable<TEntity> entities);
        int BulkUpdate(IEnumerable<TEntity> entities);
        int BulkDelete();
        IDbConnection Db { get; }
    }
}
