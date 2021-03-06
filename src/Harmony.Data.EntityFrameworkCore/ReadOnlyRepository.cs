﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Harmony.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Data.EntityFrameworkCore
{
    public class ReadOnlyRepository<TContext> : IReadOnlyRepository
        where TContext : DbContext
    {
        /// <summary>
        /// Current EF DBContext instance.
        /// </summary>
        protected readonly TContext context;

        public ReadOnlyRepository(TContext context)
        {
            this.context = context;
        }

        public TEntity Get<TEntity>(object id) where TEntity: class, IEntity {
            return context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetAsync<TEntity>(object id) where TEntity: class, IEntity
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity: class, IEntity {
            return context.Set<TEntity>().ToList<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity: class, IEntity
        {
            return await context.Set<TEntity>().ToListAsync<TEntity>();
        }
    }
}
