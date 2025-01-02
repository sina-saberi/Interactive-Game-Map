
using System.Reflection;

namespace Interactive_Map_Navigation.Helpers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InjectAttribute : Attribute
    {
    }
}