using System.Reflection;

namespace ProjectManager.Application.Mappings;

public static class Mapper
{
    public static TTarget Map<TTarget, TSource>(TSource source)
        where TTarget : new()
    {
        var target = new TTarget();

        var sourceProperties = typeof(TSource).GetProperties();
        var targetProperties = typeof(TTarget).GetProperties();

        foreach (var sourceProp in sourceProperties)
        {
            var targetProp = targetProperties.FirstOrDefault(p => p.Name.Equals(sourceProp.Name));

            if (targetProp is null || !targetProp.CanWrite)
                continue;

            var sourceValue = sourceProp.GetValue(source);

            if (
                IsCollection(sourceProp.PropertyType, out var sourceItemType)
                && IsCollection(targetProp.PropertyType, out var targetItemType)
            )
            {
                var method = typeof(Mapper)
                    .GetMethod(nameof(MapList), BindingFlags.NonPublic | BindingFlags.Static)!
                    .MakeGenericMethod(targetItemType, sourceItemType);

                var mappedList = method.Invoke(null, [ sourceValue! ]);
                targetProp.SetValue(target, mappedList);
            }
            else if (targetProp.PropertyType == sourceProp.PropertyType)
            {
                var value = sourceProp.GetValue(source);
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

    private static bool IsCollection(Type type, out Type itemType)
    {
        if (
            type.IsGenericType
            && typeof(IEnumerable<>).IsAssignableFrom(type.GetGenericTypeDefinition())
        )
        {
            itemType = type.GetGenericArguments()[0];
            return true;
        }

        var iface = type.GetInterfaces()
            .FirstOrDefault(
                i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)
            );

        if (iface is not null && type != typeof(string))
        {
            itemType = iface.GetGenericArguments()[0];
            return true;
        }

        itemType = null!;
        return false;
    }

    private static List<TTarget> MapList<TTarget, TSource>(IEnumerable<object> sourceList)
        where TTarget : new()
    {
        var result = new List<TTarget>();
        foreach (var item in sourceList.Cast<TSource>())
        {
            result.Add(Map<TTarget, TSource>(item));
        }

        return result;
    }
}
