using System;
using System.Linq;
using System.Reflection;
using Core.Common;

namespace SimpleMVP.IntegrationTests
{
    public static class Helper
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
    }
}