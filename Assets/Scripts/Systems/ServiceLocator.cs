using System;
using System.Collections.Generic;

namespace Rodlix.Asteroid
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        protected Dictionary<Type, T> _valueItems { get; }

        public ServiceLocator()
        {
            _valueItems = new Dictionary<Type, T>();
        }

        public TP Register<TP>(TP service) where TP : T
        {
            var type = typeof(TP);
            if (_valueItems.ContainsKey(type))
            {
                throw new Exception("Уже имеется");
            }
            _valueItems[type] = service;

            return service;
        }

        public TP Get<TP>() where TP : T
        {
            var type = typeof(TP);
            if (!_valueItems.ContainsKey(type))
            {
                throw new Exception("Нет в наличии");
            }

            return (TP)_valueItems[type];
        }

        public List<T> GetAll()
        {
            var list = new List<T>();
            foreach (var item in _valueItems)
            {
                list.Add(item.Value);
            }

            return list;
        }

        public void Unregister<TP>(TP service) where TP : T
        {
            var type = typeof(TP);
            if (!_valueItems.ContainsKey(type))
            {
                _valueItems.Remove(type);
            }
        }
    }
}