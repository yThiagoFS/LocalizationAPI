using System.Linq.Expressions;

namespace Localization.Domain.Common.Extensions;

public static class QueryExtensions 
{
    public static IQueryable<TSource> FilterQuery<TSource>(this IQueryable<TSource> source, IEnumerable<Expression<Func<TSource, bool>>> predicates) 
    {
        foreach(var expression in predicates) 
        {
            source = source.Where(expression);
        }

        return source;
    }
}
