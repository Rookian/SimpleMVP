using System;

namespace Infrastructure
{
    public class HybridInstanceScoper<T> : IInstanceScoper<T>
    {
        private readonly HttpContextInstanceScoper<T> _httpContextInstanceScoper;
        private readonly ThreadStaticInstanceScoper<T> _threadStaticInstanceScoper;

        public HybridInstanceScoper()
        {
            _threadStaticInstanceScoper = new ThreadStaticInstanceScoper<T>();
            _httpContextInstanceScoper = new HttpContextInstanceScoper<T>();
        }

        public T GetScopedInstance(string key, Func<T> builder)
        {
            // Get the right InstanceScoper
            IInstanceScoper<T> scoper = GetScoperToUse();
            return scoper.GetScopedInstance(key, builder);
        }

        public void ClearScopedInstance(string key)
        {
            IInstanceScoper<T> scoper = GetScoperToUse();
            scoper.ClearScopedInstance(key);
        }

        private IInstanceScoper<T> GetScoperToUse()
        {
            // Is there a HttpContext object?
            if (_httpContextInstanceScoper.IsEnabled())
            {
                return _httpContextInstanceScoper;
            }

            // No HttpContext
            return _threadStaticInstanceScoper;
        }
    }
}