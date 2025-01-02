using Interactive_Map_Navigation.Interfaces;
using System.Reflection;

namespace Interactive_Map_Navigation.Helpers
{
    public static class DependencyInjector
    {
        public static void InjectProperties<TViewModel>(this TViewModel? target, IServiceProvider serviceProvider)
            where TViewModel : INavigate
        {
            if (target == null) return;
            Inject(target, serviceProvider);
            InjectProperties(target.Layout, serviceProvider);
        }
        private static void Inject<TViewModel>(this TViewModel target, IServiceProvider serviceProvider)
            where TViewModel : INavigate
        {
            var properties = target.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.IsDefined(typeof(InjectAttribute), true) && prop.CanWrite);

            foreach (var property in properties)
            {
                var service = serviceProvider.GetService(property.PropertyType);
                if (service != null)
                {
                    property.SetValue(target, service);
                }
            }
        }
    }
}
