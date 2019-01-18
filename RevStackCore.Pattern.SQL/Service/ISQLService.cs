using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace RevStackCore.Pattern.SQL
{
    public interface ISQLService<TEntity,TKey> : IService<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        IEnumerable<TResult> ExecuteProcedure<TResult>(string sp_procedure, object param) where TResult : class;
        IEnumerable<TResult> ExecuteProcedure<TResult>(string sp_procedure) where TResult : class;
        TResult ExecuteProcedureSingle<TResult>(string sp_procedure, object param) where TResult : class;
        TResult ExecuteProcedureSingle<TResult>(string sp_procedure) where TResult : class;
        TValue ExecuteScalar<TValue>(string s_function, object param) where TValue : struct;
        TValue ExecuteScalar<TValue>(string s_function) where TValue : struct;
        TResult ExecuteFunction<TResult>(string s_function, object param) where TResult : class;
        TResult ExecuteFunction<TResult>(string s_function) where TResult : class;
        DynamicParameters Execute(string sp_procedure, DynamicParameters param);
        IEnumerable<TResult> ExecuteFunctionWithResults<TResult>(string s_function) where TResult : class;
        IEnumerable<TResult> ExecuteFunctionWithResults<TResult>(string s_function, object param) where TResult : class;
        void Execute(string sp_procedure, object param);
        void Execute(string sp_procedure);
        IDbConnection Db { get; }

        Task<IEnumerable<TResult>> ExecuteProcedureAsync<TResult>(string sp_procedure, object param) where TResult : class;
        Task<IEnumerable<TResult>> ExecuteProcedureAsync<TResult>(string sp_procedure) where TResult : class;
        Task<TResult> ExecuteProcedureSingleAsync<TResult>(string sp_procedure, object param) where TResult : class;
        Task<TResult> ExecuteProcedureSingleAsync<TResult>(string sp_procedure) where TResult : class;
        Task<TValue> ExecuteScalarAsync<TValue>(string s_function, object param) where TValue : struct;
        Task<TValue> ExecuteScalarAsync<TValue>(string s_function) where TValue : struct;
        Task<TResult> ExecuteFunctionAsync<TResult>(string s_function, object param) where TResult : class;
        Task<TResult> ExecuteFunctionAsync<TResult>(string s_function) where TResult : class;
        Task<DynamicParameters> ExecuteAsync(string sp_procedure, DynamicParameters param);
        Task<IEnumerable<TResult>> ExecuteFunctionWithResultsAsync<TResult>(string s_function) where TResult : class;
        Task<IEnumerable<TResult>> ExecuteFunctionWithResultsAsync<TResult>(string s_function, object param) where TResult : class;
        Task ExecuteAsync(string sp_procedure, object param);
        Task ExecuteAsync(string sp_procedure);
    }
}
