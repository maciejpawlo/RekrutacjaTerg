using System;
using System.Linq.Expressions;

namespace RekrutacjaTerg.Application.Common.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> ConditionalWhere<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
    }
}
