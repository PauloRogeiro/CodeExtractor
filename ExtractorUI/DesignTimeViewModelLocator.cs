using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using MvvmFramework;

namespace app {
    
    [ValueConversion(typeof(String), typeof(ViewModelObject))]
    public class DesignTimeViewModelLocator : IValueConverter {
        public static DesignTimeViewModelLocator Instance = new DesignTimeViewModelLocator();

        static DesignTimeViewModelLocator() {
            if (Execution.InDesignMode) {
                var bootstrapper = new Bootstrapper();
                bootstrapper.Start();
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var assembliesForSearchingIn = AssemblySource.Instance; 

            var allExportedTypes = new List<Type>();
            foreach (var assembly in assembliesForSearchingIn) {
                allExportedTypes.AddRange(assembly.GetExportedTypes());
            }
            var viewModelType = allExportedTypes.First(t => t.FullName == value.ToString());
            return IoC.GetInstance(viewModelType, null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }
}