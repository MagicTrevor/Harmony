using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Harmony.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Data.EntityFrameworkCore
{
    public class ReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        /// <summary>
        /// Current EF DBContext instance.
        /// </summary>
        protected virtual DbContext Context { get; set; }

        /// <summary>
        /// DBSet of <see cref="TEntity"/> extracted from <see cref="Context"/>.
        /// </summary>
        internal DbSet<TEntity> DbSet;

        public ReadOnlyRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public TEntity Get(TKey id) {
            return DbSet.Find(id);
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll() {
            return DbSet.ToList<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync<TEntity>();
        }
    }
}
