using System;
using System.Linq;
using System.Reflection;

namespace Core.Common
{
    public static class ReflectionHelper
    {
        public static T GetField<T>(this object obj)
        {
            Ensure.That(obj).IsNotNull();
            var fieldInfos = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            if (!fieldInfos.Any())
            {
                fieldInfos = obj.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            }

            if (!fieldInfos.Any())
            {
                throw new ApplicationException(string.Format("Could not find {0} in {1}", typeof(T).Name, obj.GetType().Name));
            }
            return (T)fieldInfos.FirstOrDefault(x => x.FieldType == typeof(T)).GetValue(obj);
        }

        public static TBindingType GetMemberOfType<TControl, TBindingType>(this object obj) where TBindingType : class
        {
            Ensure.That(obj).IsNotNull();
            var control = obj.GetField<TControl>();
            var propertyInfos = control.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name == "Tag");
            var value = propertyInfo.GetValue(control, null);
            var bindingValue = value as TBindingType;

            return bindingValue;
        }
    }
}