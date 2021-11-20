using DatabaseAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly bool Track;

        protected Repository(DbContext context, bool track)
        {
            Context = context;
            Track = track;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<TEntity>().Add(entity);
        }

        public Task AddAsync(TEntity entity)
        {
            throw new Exception();
            //if (entity == null)
            //{
            //    throw new ArgumentNullException(nameof(entity));
            //}

            //return Context.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Context.Set<TEntity>().AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            return Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate, string properties = "")
        {
            if (predicate == null)
            {
                return Context.Set<TEntity>().Any();
            }
            var query = (IQueryable<TEntity>)Context.Set<TEntity>();

            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(","))
                {
                    query = query.Include(property.Trim());
                }
            }

            return query.AsNoTracking().Any(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, string properties = "")
        {
            if (predicate == null)
            {
                return Context.Set<TEntity>().AnyAsync();
            }
            var query = (IQueryable<TEntity>)Context.Set<TEntity>();

            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(","))
                {
                    query = query.Include(property.Trim());
                }
            }

            return query.AsNoTracking().AnyAsync(predicate);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string properties = "")
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var query = (IQueryable<TEntity>)Context.Set<TEntity>();

            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(","))
                {
                    query = query.Include(property);
                }
            }

            if (!Track) query = query.AsNoTracking();

            return query.Where(predicate).ToList();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string properties = "")
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var query = (IQueryable<TEntity>)Context.Set<TEntity>();

            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(","))
                {
                    query = query.Include(property);
                }
            }

            if (!Track) query = query.AsNoTracking();

            return Task.FromResult(query.Where(predicate).AsEnumerable());
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate, string properties = "")
        {
            var query = (IQueryable<TEntity>)Context.Set<TEntity>();

            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(","))
                {
                    query = query.Include(property);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (!Track) query = query.AsNoTracking();

            return query.FirstOrDefault();
        }

        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, string properties = "")
        {
            var query = (IQueryable<TEntity>)Context.Set<TEntity>();

            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(","))
                {
                    query = query.Include(property);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (!Track) query = query.AsNoTracking();

            return query.FirstOrDefaultAsync();
        }

        public TEntity Get(TKey id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll(string properties = "")
        {
            var query = (IQueryable<TEntity>)Context.Set<TEntity>();

            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(","))
                {
                    query = query.Include(property);
                }
            }

            if (!Track) query = query.AsNoTracking();

            return query.ToList();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(string properties = "")
        {
            var query = (IQueryable<TEntity>)Context.Set<TEntity>();

            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(","))
                {
                    query = query.Include(property);
                }
            }

            if (!Track) query = query.AsNoTracking();

            return Task.FromResult(query.AsEnumerable());
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            throw new Exception();
            //if (id == null)
            //{
            //	throw new ArgumentNullException(nameof(id));
            //}

            //return Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Context.Set<TEntity>().UpdateRange(entities);
        }

        public virtual void AddOrUpdate(TEntity entity, Func<TEntity, TKey> key, string properties = "")
        {
            var entry = Get(key.Invoke(entity));

            if (entry == null)
            {
                Add(entity);
            }
            else
            {
                var originalEntry = Context.Entry(entity);
                Context.Entry(entry).CurrentValues.SetValues(entity);
                foreach (var navigation in Context.Entry(entry).Navigations)
                {
                    navigation.Load();
                    navigation.CurrentValue = originalEntry.Navigation(navigation.Metadata.Name).CurrentValue;
                    navigation.IsModified = true;
                }
                Update(entry);
            }
        }
    }
}

