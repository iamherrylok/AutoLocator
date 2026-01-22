namespace AutoLocator.Interfaces
{
    public static class IContainerRegistryExtensions
    {
        extension(IContainerRegistry containerRegistry)
        {
            public IContainerRegistry RegisterInstance<T>(T instance)
                => containerRegistry.RegisterInstance(typeof(T), instance!);

            public IContainerRegistry RegisterInstance<T>(T instance, string name)
                => containerRegistry.RegisterInstance(typeof(T), instance!, name);

            public IContainerRegistry Register(Type type)
                => containerRegistry.Register(type, type);

            public IContainerRegistry Register(Type type, string name)
                => containerRegistry.Register(type, type, name);

            public IContainerRegistry Register<T>()
                => containerRegistry.Register(typeof(T));

            public IContainerRegistry Register<T>(string name)
                => containerRegistry.Register(typeof(T), name);

            public IContainerRegistry Register<T>(Func<object> factoryMethod)
                => containerRegistry.Register(typeof(T), factoryMethod);

            public IContainerRegistry Register<T>(Func<IContainerProvider, object> factoryMethod)
                => containerRegistry.Register(typeof(T), factoryMethod);

            public IContainerRegistry Register<TFrom, TTo>() where TTo : TFrom
                => containerRegistry.Register(typeof(TFrom), typeof(TTo));

            public IContainerRegistry Register<TFrom, TTo>(string name) where TTo : TFrom
                => containerRegistry.Register(typeof(TFrom), typeof(TTo), name);

            public IContainerRegistry RegisterSingleton(Type type)
                => containerRegistry.RegisterSingleton(type, type);

            public IContainerRegistry RegisterSingleton<T>()
                => containerRegistry.RegisterSingleton(typeof(T));

            public IContainerRegistry RegisterSingleton<T>(Func<object> factoryMethod)
                => containerRegistry.RegisterSingleton(typeof(T), factoryMethod);

            public IContainerRegistry RegisterSingleton<T>(Func<IContainerProvider, object> factoryMethod)
                => containerRegistry.RegisterSingleton(typeof(T), factoryMethod);

            public IContainerRegistry RegisterSingleton<TFrom, TTo>() where TTo : TFrom
                => containerRegistry.RegisterSingleton(typeof(TFrom), typeof(TTo));

            public IContainerRegistry RegisterSingleton<TFrom, TTo>(string name) where TTo : TFrom
                => containerRegistry.RegisterSingleton(typeof(TFrom), typeof(TTo), name);

            public IContainerRegistry RegisterScoped(Type type)
                => containerRegistry.RegisterScoped(type, type);

            public IContainerRegistry RegisterScoped<T>()
                => containerRegistry.RegisterScoped(typeof(T));

            public IContainerRegistry RegisterScoped<T>(Func<object> factoryMethod)
                => containerRegistry.RegisterScoped(typeof(T), factoryMethod);

            public IContainerRegistry RegisterScoped<T>(Func<IContainerProvider, object> factoryMethod)
                => containerRegistry.RegisterScoped(typeof(T), factoryMethod);

            public IContainerRegistry RegisterScoped<TFrom, TTo>() where TTo : TFrom
                => containerRegistry.RegisterScoped(typeof(TFrom), typeof(TTo));

            public bool IsRegistered<T>()
                => containerRegistry.IsRegistered(typeof(T));

            public bool IsRegistered<T>(string name)
                => containerRegistry.IsRegistered(typeof(T), name);
        }
    }
}
