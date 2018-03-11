using System;
using System.Linq.Expressions;

namespace Harmony.Core.Models {
    public abstract class Specification<TEntity> {
        public abstract Expression<Func<TEntity, bool>> ToExpression();

        public bool IsSatisfiedBy(TEntity entity) {
            Func<TEntity, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}