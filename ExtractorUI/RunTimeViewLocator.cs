using System;
using System.Collections.Generic;
using System.Linq;
using MvvmFramework;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace app
{
    public static class RunTimeViewLocator
    {
        public static Object GetAutoLocateView(DependencyObject obj)
        {
            return (Object)obj.GetValue(AutoLocateViewProperty);
        }

        public static void SetAutoLocateView(DependencyObject obj, Object value)
        {
            obj.SetValue(AutoLocateViewProperty, value);
        }

   

        public static readonly DependencyProperty AutoLocateViewProperty =
            DependencyProperty.RegisterAttached("AutoLocateView",
                typeof(Object), typeof(RunTimeViewLocator),
                new PropertyMetadata(null, AutoLocateViewChanged));

       


        private static void AutoLocateViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d))
            {
                return;
            }

            if (e.NewValue == null)
            {
                return;
            }

            ContentControl c = (ContentControl)d;

            var modelType = e.NewValue.GetType();
            string viewTypeName = modelType.FullName.Replace("ViewModel", "View");
            var allExportedTypes = new List<Type>();

            allExportedTypes.AddRange(typeof(RunTimeViewLocator).Assembly.GetExportedTypes());

            Type viewModelType = allExportedTypes.Single(x => x.FullName.Equals(viewTypeName));
            object viewModel = IoC.GetInstance(viewModelType, null);
            c.Content = viewModel;
        }






    }
}