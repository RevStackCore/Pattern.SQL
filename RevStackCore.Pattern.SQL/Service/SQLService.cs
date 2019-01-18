using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace RevStackCore.Pattern.SQL
{
    public class SQLService<TEntity, TKey> : ISQLService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly ISQLRepository<TEntity, TKey> _repository;
        public SQLService(ISQLRepository<TEntity, TKey> repository)
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

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            return Task.Run(() => Delete(entity));
        }

        public DynamicParameters Execute(string sp_procedure, DynamicParameters param)
        {
            return _repository.Execute(sp_procedure, param);
        }

        public void Execute(string sp_procedure, object param)
        {
            _repository.Execute(sp_procedure, param);
        }

        public void Execute(string sp_procedure)
        {
            _repository.Execute(sp_procedure);
        }

        public Task<DynamicParameters> ExecuteAsync(string sp_procedure, DynamicParameters param)
        {
            return Task.FromResult(Execute(sp_procedure, param));
        }

        public Task ExecuteAsync(string sp_procedure, object param)
        {
            return Task.Run(() => Execute(sp_procedure,param));
        }

        public Task ExecuteAsync(string sp_procedure)
        {
            return Task.Run(() => Execute(sp_procedure));
        }

        public TResult ExecuteFunction<TResult>(string s_function, object param) where TResult : class
        {
            return _repository.ExecuteFunction<TResult>(s_function, param);
        }

        public TResult ExecuteFunction<TResult>(string s_function) where TResult : class
        {
            return _repository.ExecuteFunction<TResult>(s_function);
        }

        public Task<TResult> ExecuteFunctionAsync<TResult>(string s_function, object param) where TResult : class
        {
            return Task.FromResult(ExecuteFunction<TResult>(s_function, param));
        }

        public Task<TResult> ExecuteFunctionAsync<TResult>(string s_function) where TResult : class
        {
            return Task.FromResult(ExecuteFunction<TResult>(s_function));
        }

        public IEnumerable<TResult> ExecuteFunctionWithResults<TResult>(string s_function) where TResult : class
        {
            return _repository.ExecuteFunctionWithResults<TResult>(s_function);
        }

        public IEnumerable<TResult> ExecuteFunctionWithResults<TResult>(string s_function, object param) where TResult : class
        {
            return _repository.ExecuteFunctionWithResults<TResult>(s_function,param);
        }

        public Task<IEnumerable<TResult>> ExecuteFunctionWithResultsAsync<TResult>(string s_function) where TResult : class
        {
            return Task.FromResult(ExecuteFunctionWithResults<TResult>(s_function));
        }

        public Task<IEnumerable<TResult>> ExecuteFunctionWithResultsAsync<TResult>(string s_function, object param) where TResult : class
        {
            return Task.FromResult(ExecuteFunctionWithResults<TResult>(s_function,param));
        }

        public IEnumerable<TResult> ExecuteProcedure<TResult>(string sp_procedure, object param) where TResult : class
        {
            return _repository.ExecuteProcedure<TResult>(sp_procedure, param);
        }

        public IEnumerable<TResult> ExecuteProcedure<TResult>(string sp_procedure) where TResult : class
        {
            return _repository.ExecuteProcedure<TResult>(sp_procedure);
        }

        public Task<IEnumerable<TResult>> ExecuteProcedureAsync<TResult>(string sp_procedure, object param) where TResult : class
        {
            return Task.FromResult(ExecuteProcedure<TResult>(sp_procedure, param));
        }

        public Task<IEnumerable<TResult>> ExecuteProcedureAsync<TResult>(string sp_procedure) where TResult : class
        {
            return Task.FromResult(ExecuteProcedure<TResult>(sp_procedure));
        }

        public TResult ExecuteProcedureSingle<TResult>(string sp_procedure, object param) where TResult : class
        {
            return _repository.ExecuteProcedureSingle<TResult>(sp_procedure,param);
        }

        public TResult ExecuteProcedureSingle<TResult>(string sp_procedure) where TResult : class
        {
            return _repository.ExecuteProcedureSingle<TResult>(sp_procedure);
        }

        public Task<TResult> ExecuteProcedureSingleAsync<TResult>(string sp_procedure, object param) where TResult : class
        {
            return Task.FromResult(ExecuteProcedureSingle<TResult>(sp_procedure, param));
        }

        public Task<TResult> ExecuteProcedureSingleAsync<TResult>(string sp_procedure) where TResult : class
        {
            return Task.FromResult(ExecuteProcedureSingle<TResult>(sp_procedure));
        }

        public TValue ExecuteScalar<TValue>(string s_function, object param) where TValue : struct
        {
            return _repository.ExecuteScalar<TValue>(s_function, param);
        }

        public TValue ExecuteScalar<TValue>(string s_function) where TValue : struct
        {
            return _repository.ExecuteScalar<TValue>(s_function);
        }

        public Task<TValue> ExecuteScalarAsync<TValue>(string s_function, object param) where TValue : struct
        {
            return Task.FromResult(ExecuteScalar<TValue>(s_function, param));
        }

        public Task<TValue> ExecuteScalarAsync<TValue>(string s_function) where TValue : struct
        {
            return Task.FromResult(ExecuteScalar<TValue>(s_function));
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
