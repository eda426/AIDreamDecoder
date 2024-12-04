using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AIDreamDecoder.Domain.Specifications
{
    public abstract class BaseSpecification<T>
    {
        // Filtreleme kriterlerini tutan bir ifade
        public Expression<Func<T, bool>> Criteria { get; }

        // Sıralama işlevi
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; private set; }

        // Sıralama (azalan) işlevi
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending { get; private set; }

        // Alınacak maksimum sonuç sayısı
        public int? Take { get; private set; }

        // Atlanacak sonuç sayısı
        public int? Skip { get; private set; }

        // Ek yüklenecek ilişkiler (Include işlemi için)
        public List<Expression<Func<T, object>>> Includes { get; } = new();

        // Yapıcı metot: Temel filtreleme kriteri alır
        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        // Varsayılan kurucu
        protected BaseSpecification() { }

        // Sıralama ekler
        protected void AddOrderBy<TKey>(Expression<Func<T, TKey>> orderByExpression)
        {
            OrderBy = query => query.OrderBy(orderByExpression);
        }

        // Azalan sıralama ekler
        protected void AddOrderByDescending<TKey>(Expression<Func<T, TKey>> orderByDescendingExpression)
        {
            OrderByDescending = query => query.OrderByDescending(orderByDescendingExpression);
        }

        // Sayfalama için atlama sayısı ekler
        protected void AddSkip(int skip)
        {
            Skip = skip;
        }

        // Sayfalama için maksimum alınacak sonuç sayısı ekler
        protected void AddTake(int take)
        {
            Take = take;
        }

        // İlişki yükleme (Include) işlemi ekler
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
