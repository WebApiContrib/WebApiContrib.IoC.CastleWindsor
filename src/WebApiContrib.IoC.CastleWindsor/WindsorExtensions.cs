namespace WebApiContrib.IoC.CastleWindsor
{
    using System;
    using System.Linq;
    using Castle.Windsor;

    public static class WindsorExtensions
    {
        public static T BuildUp<T>(this IWindsorContainer container, T instance) where T : class
        {
            if (instance == null)
            {
                return null;
            }

            var properties =
                instance.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(DependencyAttribute)));

            foreach (var property in properties)
            {
                var value = property.GetValue(instance, null);

                if (value != null)
                {
                    continue;
                }

                var resolvedPropertyInstance = container.Resolve(property.PropertyType);

                property.SetValue(instance, resolvedPropertyInstance);
            }

            return instance;
        }
    }
}