using System;

namespace Core.Common
{
    public static class Ensure
    {
        public static EnsureExpression<T> That<T>(T obj, string parameterName = "Argument") where T : class
        {
            return new EnsureExpression<T>(obj, parameterName);
        }

        public class EnsureExpression<T> where T : class
        {
            readonly T _obj;
            readonly string _parameterName;

            public EnsureExpression(T obj, string parameterName)
            {
                _obj = obj;
                _parameterName = parameterName;
            }

            public void IsNotNull()
            {
                if (_obj == null)
                {
                    throw new ArgumentException(String.Format("{0} of type {1} is null.", _parameterName, typeof (T).Name));
                }
            }
        }
    }
}