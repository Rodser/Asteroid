using System.Collections.Generic;
using System;

namespace Assets.Scripts
{
    internal static class DIContainer
    {
        private static readonly Dictionary<Type, object> _container = new();

        public static void Bind<T>(T value) where T : class
        {

        }

        public static T Get<T>() where T : class
        {
            return null;
        }

        public static T[] GetAll<T>() where T : class
        {
            return null;
        }

        public static void Unbind<T>() where T : class
        {

        }

    }
}