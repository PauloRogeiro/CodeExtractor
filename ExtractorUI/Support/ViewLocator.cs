using System;
using System.Collections.Generic;
using System.Linq;
using MvvmFramework;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace app
{
    public static class ViewLocator
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
                typeof(Object), typeof(ViewLocator),
                new PropertyMetadata(null, AutoLocateViewChanged));

       


        private static void AutoLocateViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            String viewModelName = "ViewModel";
            if (e.NewValue == null)
            {
                return;
            }


            if (DesignerProperties.GetIsInDesignMode(d))
            {
                viewModelName += "Design";
            }


            ContentControl c = (ContentControl)d;

            var modelType = e.NewValue.GetType();
            string viewTypeName = modelType.FullName.Replace(viewModelName, "View");
            var allExportedTypes = new List<Type>();

            allExportedTypes.AddRange(typeof(ViewLocator).Assembly.GetExportedTypes());

            Type viewModelType = allExportedTypes.Single(x => x.FullName.Equals(viewTypeName));
            object view = IoC.GetInstance(viewModelType, null);
            c.Content = view;
        }






    }
}