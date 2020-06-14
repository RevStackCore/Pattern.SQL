using System;
using System.Collections.Generic;
using System.Data;

namespace RevStackCore.Pattern.SQL
{
    public interface IBulkRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        void BulkInsert(IEnumerable<TEntity> entities);
        void BulkUpdate(IEnumerable<TEntity> entities);
        IDbConnection Db { get; }
    }
}
