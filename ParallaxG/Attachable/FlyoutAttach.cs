using ParallaxG.CustomControls;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ParallaxG.Attachable
{
    public class FlyoutAttach
    {
        public static FlyoutControl GetFlyout(ButtonBase button)
            => (FlyoutControl)button.GetValue(FlyoutProperty);

        public static void SetFlyout(ButtonBase button, FlyoutControl value)
            => button.SetValue(FlyoutProperty, value);

        public static readonly DependencyProperty FlyoutProperty =
            DependencyProperty.RegisterAttached("Flyout",
                                                typeof(FlyoutControl),
                                                typeof(FlyoutAttach),
                                                new PropertyMetadata(null,
                                                new PropertyChangedCallback((s, e) =>
                                                {
                                                    if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
                                                    if (s is ButtonBase button && e.NewValue is FlyoutControl newFlyout)
                                                    {
                                                        if (Application.Current.MainWindow.Content is Grid grid)
                                                        {
                                                            if (e.OldValue is FlyoutControl oldFlyout)
                                                            {
                                                                grid.Children.Remove(oldFlyout);
                                                            }

                                                            if (!grid.Children.Contains(newFlyout))
                                                            {
                                                                grid.Children.Add(newFlyout);
                                                            }

                                                            button.Click -= buttonClick;
                                                            button.Click += buttonClick;
                                                        }
                                                        else
                                                        {
                                                            throw new Exception($"{nameof(Application.Current.MainWindow)} must have a root layout panel of type {nameof(Grid)} in order to use attachable Flyout.");
                                                        }

                                                        void buttonClick(object sender, RoutedEventArgs routedEventArgs)
                                                        {
                                                            newFlyout.IsOpen = true;
                                                        }
                                                    }
                                                })));
    }
}
