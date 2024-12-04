using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Specifications
{
    public abstract class BaseSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; private set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending { get; private set; }
        public int? Take { get; private set; }
        public int? Skip { get; private set; }

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            OrderBy = orderBy;
        }

        protected void AddOrderByDescending(Func<IQueryable<T>, IOrderedQueryable<T>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }

        protected void AddTake(int take)
        {
            Take = take;
        }

        protected void AddSkip(int skip)
        {
            Skip = skip;
        }
    }
}
