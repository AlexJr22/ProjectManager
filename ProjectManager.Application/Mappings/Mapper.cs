namespace ProjectManager.Application.Mappings;

public static class Mapper
{
    public static Target Map<Target, Souce>(Souce souce)
        where Target : new()
    {
        var target = new Target();

        var souceProperty = typeof(Souce).GetProperties();
        var targetProperty = typeof(Target).GetProperties();

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
}
