using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Interfaces
{
	public interface IRepository<TEntity, TKey> where TEntity : class
	{
		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string properties = "");
		TEntity Get(TKey id);
		Task<TEntity> GetAsync(TKey id);
		IEnumerable<TEntity> GetAll(string properties = null);
		Task<IEnumerable<TEntity>> GetAllAsync(string properties = null);
		TEntity First(Expression<Func<TEntity, bool>> predicate, string properties = null);
		Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, string properties = null);

		void Add(TEntity entity);
		Task AddAsync(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
		Task AddRangeAsync(IEnumerable<TEntity> entities);

		void Update(TEntity entity);
		void UpdateRange(IEnumerable<TEntity> entities);

		bool Any(Expression<Func<TEntity, bool>> predicate, string properties = "");
		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, string properties = "");

		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);

		void AddOrUpdate(TEntity entity, Func<TEntity, TKey> key, string properties = "");
	}
}
