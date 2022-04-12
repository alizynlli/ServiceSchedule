using System.ComponentModel;
using System.Reflection;

namespace NBA.ServiceSchedule.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string DescriptionAttr<T>(this T source)
        {
            var fi = source?.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi?.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes?.Length > 0 ? attributes[0].Description : source?.ToString();
        }

        public static string Description(this FieldInfo fieldInfo)
        {
            var attributes = (DescriptionAttribute[])fieldInfo?.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes?.Length > 0 ? attributes[0].Description : fieldInfo?.ToString();
        }
    }
}
