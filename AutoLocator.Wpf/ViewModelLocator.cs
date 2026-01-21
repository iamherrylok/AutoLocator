using System.ComponentModel;
using System.Windows;

namespace AutoLocator.Wpf
{
    public class ViewModelLocator
    {
        public static readonly DependencyProperty AutoWireViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, OnAutoWireViewModelChanged));

        public static bool GetAutoWireViewModel(DependencyObject obj)
            => (bool)obj.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
            => obj.SetValue(AutoWireViewModelProperty, value);

        private static void OnAutoWireViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d))
                return;

            var value = (bool?)e.NewValue;
            if (value.HasValue && value.Value)
            {
                ViewModelLocationProvider.AutoWireViewModelChanged(d, Bind);
            }
        }

        static void Bind(object view, object viewModel)
        {
            if (view is FrameworkElement element)
                element.DataContext = viewModel;
        }
    }
}
