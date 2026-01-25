using System.Globalization;
using System.Reflection;

namespace AutoLocator.Avalonia;

public static class ViewModelLocationProvider
{
    static Func<Type, object> _defaultViewModelFactory
        = type => Activator.CreateInstance(type) ??
                  throw new Exception("Unable to create an instance of " + type.FullName);

    public static void Initialize(Func<Type, object> viewModelFactory)
    {
        _defaultViewModelFactory = viewModelFactory;
    }

    public static void AutoWireViewModelChanged(object view, Action<object, object> setDataContextCallback)
    {
        var viewType = view.GetType();
        var viewModelType = DefaultViewTypeToViewModel(viewType);

        if (viewModelType == null)
            return;

        var viewModel = _defaultViewModelFactory(viewModelType);

        setDataContextCallback(view, viewModel);
    }

    private static Type? DefaultViewTypeToViewModel(Type viewType)
    {
        var viewName = viewType.FullName;
        viewName = viewName?.Replace(".Views.", ".ViewModels.");
        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        var suffix = viewName != null && viewName.EndsWith("View") ? "Model" : "ViewModel";
        var viewModelName =
            string.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewAssemblyName);
        return Type.GetType(viewModelName);
    }
}