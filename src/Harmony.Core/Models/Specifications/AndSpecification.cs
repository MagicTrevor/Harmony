using System;
using System.Linq;
using System.Linq.Expressions;
using Harmony.Core.Models;

namespace Harmony.Core.Specifications
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _right = right;
            _left = left;
        }

        public Expression<Func<T, bool>> IsSatisfiedBy()
        {
            var leftExpression = _left.IsSatisfiedBy();
            var rightExpression = _right.IsSatisfiedBy();

            var andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }
}