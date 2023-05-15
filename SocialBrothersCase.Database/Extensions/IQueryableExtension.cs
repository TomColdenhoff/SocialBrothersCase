using System.Linq.Expressions;
using System.Reflection;

namespace SocialBrothersCase.Database.Extensions;

public static class IQueryableExtension
{
    public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, string filter)
    {
        var entityType = typeof(TEntity);
        
        var equalLambda = BuildWhereExpression<TEntity>(filter, entityType);
        
        var whereMethod = typeof(Queryable)
            .GetMethods()
            .Where(m => m.Name == "Where" && m.IsGenericMethodDefinition)
            .First(m => m.GetParameters().ToList().Count == 2);
        var genericWhereMethod = whereMethod.MakeGenericMethod(entityType);
        query = (IQueryable<TEntity>)genericWhereMethod.Invoke(genericWhereMethod, new object[] { query, equalLambda })!;
        
        return query;
    }

    private static LambdaExpression BuildWhereExpression<TEntity>(string filter, Type entityType)
    {
        var entityProperties = typeof(TEntity).GetProperties().Where(p => p.PropertyType == typeof(string));
        var parameter = Expression.Parameter(entityType, "entity");
        var filterConstant = Expression.Constant(filter);

        var equalExpressions = new List<BinaryExpression>();
        foreach (var entityProperty in entityProperties)
        {
            var property = Expression.MakeMemberAccess(parameter, entityProperty);
            equalExpressions.Add(Expression.Equal(property, filterConstant));
        }

        BinaryExpression orExpression = equalExpressions.First();
        foreach (var binaryExpression in equalExpressions.Skip(1))
        {
            orExpression = Expression.Or(orExpression, binaryExpression);
        }

        var equalLambda = Expression.Lambda(orExpression, parameter);
        return equalLambda;
    }

    public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, string propertyName, bool descending)
    {
        var type = typeof(TEntity);
        
        var propertyInfo = GetPropertyInfo(type, propertyName);
        if (propertyInfo == null)
        {
            return (IOrderedQueryable<TEntity>)query;
        }

        var parameter = Expression.Parameter(type, "entity");
        var property = Expression.MakeMemberAccess(parameter, propertyInfo);
        var selector = Expression.Lambda(property, new ParameterExpression[] { parameter });
        
        var orderBymethod = typeof(Queryable)
            .GetMethods()
            .Where(m => m.Name == (descending ? "OrderByDescending" : "OrderBy") && m.IsGenericMethodDefinition)
            .Single(m => m.GetParameters().ToList().Count == 2);
        
        var genericOrderByMethod = orderBymethod.MakeGenericMethod(type, propertyInfo.PropertyType);
        
        return (IOrderedQueryable<TEntity>)genericOrderByMethod.Invoke(genericOrderByMethod, new object[] { query, selector })!;
    }

    private static PropertyInfo? GetPropertyInfo(Type type, string propertyName)
    {
        return type.GetProperty(propertyName, BindingFlags.IgnoreCase |  BindingFlags.Public | BindingFlags.Instance);
    }
}