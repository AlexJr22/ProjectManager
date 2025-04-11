namespace ProjectManager.Application.Mappings;

public static class Mapper
{
    public static TTarget Map<TTarget, TSouce>(TSouce souce)
        where TTarget : new()
    {
        var target = new TTarget();

        var souceProperty = typeof(TSouce).GetProperties();
        var targetProperty = typeof(TTarget).GetProperties();

        foreach (var property in souceProperty)
        {
            var targetProp = targetProperty.FirstOrDefault(
                p => p.Name == property.Name && p.PropertyType == property.PropertyType
            );

            if (targetProp is not null && targetProp.CanWrite)
            {
                var value = property.GetValue(souce);
                targetProp.SetValue(target, value);
            }
        }

        return target;
    }

    public static IEnumerable<TTarget> Map<TTarget, TSource>(IEnumerable<TSource> sourceList)
        where TTarget : new()
    {
        foreach (var item in sourceList)
        {
            yield return Map<TTarget, TSource>(item);
        }
    }
}
