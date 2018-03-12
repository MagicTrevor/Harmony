using System;
using System.Linq.Expressions;
using Harmony.Core.Specifications;

namespace Harmony.Core.Models
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
    }
}