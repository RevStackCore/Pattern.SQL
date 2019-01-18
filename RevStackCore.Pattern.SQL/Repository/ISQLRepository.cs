using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace RevStackCore.Pattern.SQL
{
    public interface ISQLRepository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity:class, IEntity<TKey>
    {
        IEnumerable<TResult> ExecuteProcedure<TResult>(string sp_procedure, object param) where TResult : class;
        IEnumerable<TResult> ExecuteProcedure<TResult>(string sp_procedure) where TResult : class;
        TResult ExecuteProcedureSingle<TResult>(string sp_procedure, object param) where TResult : class;
        TResult ExecuteProcedureSingle<TResult>(string sp_procedure) where TResult : class;
        TValue ExecuteScalar<TValue>(string s_function, object param) where TValue : struct;
        TValue ExecuteScalar<TValue>(string s_function) where TValue : struct;
        TResult ExecuteFunction<TResult>(string s_function, object param) where TResult : class;
        TResult ExecuteFunction<TResult>(string s_function) where TResult : class;
        IEnumerable<TResult> ExecuteFunctionWithResults<TResult>(string s_function) where TResult : class;
        IEnumerable<TResult> ExecuteFunctionWithResults<TResult>(string s_function, object param) where TResult : class;
        DynamicParameters Execute(string sp_procedure, DynamicParameters param);
        void Execute(string sp_procedure, object param);
        void Execute(string sp_procedure);
        IDbConnection Db { get; }
    }
}
