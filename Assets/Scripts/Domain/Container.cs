using System.Collections.Generic;
using System;

namespace Rodlix.Asteroid
{
    internal static class Container
    {
        private static readonly Dictionary<Type, object> _container = new();

        public static void Bind<T>(T value) where T : class
        {
            _container.Add(typeof(T), value);
        }

        public static T Get<T>() where T : class
        {
            _container.TryGetValue(typeof(T), out var value);
            return (T)value;
        }

        public static void Unbind<T>() where T : class
        {
            _container.Remove(typeof(T));
        }
    }
}