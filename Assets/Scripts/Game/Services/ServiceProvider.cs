using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Services
{
    public static class ServiceProvider
    {
        static readonly Dictionary<Type, IService> services = new();

        public static void Register<T>(T service) where T : IService
        {
            services.Add(typeof(T), service);
        }

        public static void Unregister<T>() where T : IService
        {
            services.Remove(typeof(T));
        }

        public static T Get<T>() where T : class, IService
        {
            if (services.TryGetValue(typeof(T), out var service))
            {
                return service as T;
            }
            else
            {
                Debug.LogWarning($"{typeof(T).Name} service not found");
                return null;
            }
        }
    }
}