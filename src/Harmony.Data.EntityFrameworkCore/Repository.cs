﻿//
// Repository.cs
//
// Author:
//       Trevor Allen <MagicTrevor.icloud.com>
//
// Copyright (c) 2017 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Harmony.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Data.EntityFrameworkCore
{
    public abstract class Repository<Tcontext> : ReadOnlyRepository<Tcontext>, IRepository
        where Tcontext : DbContext
    {
        protected Repository(Tcontext context)
            : base(context)
        {
        }

        public virtual void Insert<TEntity>(TEntity entity) where TEntity: class, IEntity
        {
            context.Set<TEntity>().Add(entity);
        }

        public async virtual Task InsertAsync<TEntity>(TEntity entity) where TEntity: class, IEntity
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity: class, IEntity
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public async virtual Task UpdateAsync<TEntity>(TEntity entity) where TEntity: class, IEntity
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity: class, IEntity {
            context.Set<TEntity>().Remove(entity);
        }
    }
}
