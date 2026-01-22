using AutoLocator.Containers;
using AutoLocator.Interfaces;

namespace AutoLocator
{
    public static class ContainerProvider
    {
        private static IContainerBase? _container;

        public static IContainerBase Current => _container
            ?? throw new InvalidOperationException("You must initialize the Current Container.");

        public static void Initialize(ContainerType containerType)
        {
            _container = containerType switch
            {
                ContainerType.DryIoc => new DryIocContainer(),

                _ => throw new NotSupportedException($"The container type '{containerType}' is not supported.")
            };
        }

        public static void Initialize(IContainerBase container)
            => _container = container;

        public static void ResetContainer()
            => _container = null;
    }
}
