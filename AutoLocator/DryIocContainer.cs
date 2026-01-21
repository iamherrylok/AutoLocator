using DryIoc;

namespace AutoLocator
{
    public class DryIocContainer : IContainerBase
    {
        private readonly Container _container = new(CreateDefaultRules());

        private static Rules CreateDefaultRules()
            =>
            Rules.Default
                .WithConcreteTypeDynamicRegistrations(reuse: Reuse.Transient)
                .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
                .WithFuncAndLazyWithoutRegistration()
                .WithTrackingDisposableTransients()
                .WithFactorySelector(Rules.SelectLastRegisteredFactory());

        public bool IsRegistered(Type type) => _container.IsRegistered(type);

        public bool IsRegistered(Type type, string name)
        {
            if (_container.IsRegistered(type, name))
                return true;

            return _container.IsRegistered(type, name, FactoryType.Wrapper);
        }

        public IContainerRegistry Register(Type from, Type to)
        {
            _container.Register(from, to, Reuse.Transient);
            return this;
        }

        public IContainerRegistry Register(Type from, Type to, string name)
        {
            _container.Register(from, to, Reuse.Transient, ifAlreadyRegistered: IfAlreadyRegistered.Replace, serviceKey: name);
            return this;
        }

        public IContainerRegistry Register(Type type, Func<object> factoryMethod)
        {
            _container.RegisterDelegate(type, r => factoryMethod(), Reuse.Transient);
            return this;
        }

        public IContainerRegistry Register(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            _container.RegisterDelegate(type, factoryMethod, Reuse.Transient);
            return this;
        }

        public IContainerRegistry RegisterInstance(Type type, object instance)
        {
            _container.RegisterInstance(type, instance);
            return this;
        }

        public IContainerRegistry RegisterInstance(Type type, object instance, string name)
        {
            _container.RegisterInstance(type, instance, ifAlreadyRegistered: IfAlreadyRegistered.Replace, serviceKey: name);
            return this;
        }

        public IContainerRegistry RegisterScoped(Type from, Type to)
        {
            _container.Register(from, to, Reuse.ScopedOrSingleton);
            return this;
        }

        public IContainerRegistry RegisterScoped(Type type, Func<object> factoryMethod)
        {
            _container.RegisterDelegate(type, r => factoryMethod(), Reuse.ScopedOrSingleton);
            return this;
        }

        public IContainerRegistry RegisterScoped(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            _container.RegisterDelegate(type, factoryMethod, Reuse.ScopedOrSingleton);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to)
        {
            _container.Register(from, to, Reuse.Singleton);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to, string name)
        {
            _container.Register(from, to, Reuse.Singleton, ifAlreadyRegistered: IfAlreadyRegistered.Replace, serviceKey: name);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type type, Func<object> factoryMethod)
        {
            _container.RegisterDelegate(type, r => factoryMethod(), Reuse.Singleton);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            _container.RegisterDelegate(type, factoryMethod, Reuse.Singleton);
            return this;
        }

        public object Resolve(Type type)
        {
            // TODO: Handle unregistered concrete types exceptions if needed
            return _container.Resolve(type);
        }

        public object Resolve(Type type, string name)
        {
            // TODO: Handle unregistered concrete types exceptions if needed
            return _container.Resolve(type, serviceKey: name);
        }
    }
}
