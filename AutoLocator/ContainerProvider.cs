namespace AutoLocator
{
    public static class ContainerProvider
    {
        private static IContainerBase? _container;

        public static IContainerBase Current => _container
            ?? throw new InvalidOperationException("You must initialize the Current Container.");

        public static void SetContainer(IContainerBase container)
            => _container = container;

        public static void ResetContainer()
            => _container = null;
    }
}
