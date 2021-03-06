﻿//
// BaseController.cs
//
// Author:
//       Trevor Allen <magictrevor@icloud.com>
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

using System.Collections.Generic;
using System.Threading.Tasks;
using Harmony.Core.Models;
using Harmony.Data;
using Microsoft.AspNetCore.Mvc;

namespace Harmony.Web
{
    [Route("api/[controller]")]
    public abstract class ApiController<TEntity, TKey> : ControllerBase where TEntity : Entity<TKey>
    {
        protected readonly IReadOnlyRepository _repository;

        protected ApiController(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public virtual async Task<TEntity> Get(object id)
        {
            return await _repository.GetAsync<TEntity>(id);
        }

        [HttpGet()]
        public virtual async Task<IEnumerable<TEntity>> List()
        {
            return await _repository.GetAllAsync<TEntity>();
        }
    }
}
