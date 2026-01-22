namespace AutoLocator.Interfaces
{
    public interface IContainerProvider
    {
        object Resolve(Type type);

        object Resolve(Type type, string name);
    }
}
