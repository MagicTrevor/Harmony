using System;
using System.Linq.Expressions;

namespace Harmony.Core.Models
{
    public class Specification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Expression { get; }

        public Specification(Expression<Func<TEntity, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}