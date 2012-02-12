using System;
using System.Collections;
using System.Collections.Generic;

namespace Infrastructure
{
    public class ThreadStaticInstanceScoper<T> : InstanceScoperBase<T>
    {
        [ThreadStatic]
        private static readonly IDictionary Dictionary = new Dictionary<string, T>();

        protected override IDictionary GetDictionary()
        {
            return Dictionary;
        }
    }
}
