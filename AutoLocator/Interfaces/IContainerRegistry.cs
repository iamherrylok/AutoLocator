namespace AutoLocator.Interfaces
{
    public interface IContainerRegistry
    {
        IContainerRegistry RegisterInstance(Type type, object instance);

        IContainerRegistry RegisterInstance(Type type, object instance, string name);

        IContainerRegistry Register(Type from, Type to);

        IContainerRegistry Register(Type from, Type to, string name);

        IContainerRegistry Register(Type type, Func<object> factoryMethod);

        IContainerRegistry Register(Type type, Func<IContainerProvider, object> factoryMethod);

        IContainerRegistry RegisterSingleton(Type from, Type to);

        IContainerRegistry RegisterSingleton(Type from, Type to, string name);

        IContainerRegistry RegisterSingleton(Type type, Func<object> factoryMethod);

        IContainerRegistry RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod);

        IContainerRegistry RegisterScoped(Type from, Type to);

        IContainerRegistry RegisterScoped(Type type, Func<object> factoryMethod);

        IContainerRegistry RegisterScoped(Type type, Func<IContainerProvider, object> factoryMethod);

        bool IsRegistered(Type type);

        bool IsRegistered(Type type, string name);
    }
}
