using Avalonia;
using Avalonia.Controls;

namespace AutoLocator.Avalonia;

public static class ViewModelLocator
{
    public static readonly AttachedProperty<bool?> AutoWireViewModelProperty =
        AvaloniaProperty.RegisterAttached<Control, bool?>("AutoWireViewModel", typeof(ViewModelLocator));

    static ViewModelLocator()
    {
        AutoWireViewModelProperty.Changed.AddClassHandler<Control>(OnAutoWireViewModelPropertyChanged);
    }

    public static void SetAutoWireViewModel(Control obj, bool? value) => obj.SetValue(AutoWireViewModelProperty, value);
    public static bool? GetAutoWireViewModel(Control obj) => obj.GetValue(AutoWireViewModelProperty);

    private static void OnAutoWireViewModelPropertyChanged(Control sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (Design.IsDesignMode)
            return;

        var value = (bool?)e.NewValue;
        if (value.HasValue && value.Value)
            ViewModelLocationProvider.AutoWireViewModelChanged(sender, Bind);
    }

    private static void Bind(object view, object viewModel)
    {
        if (view is StyledElement element)
            element.DataContext = viewModel;
    }
}