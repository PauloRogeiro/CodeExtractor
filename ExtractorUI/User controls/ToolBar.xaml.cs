using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace app.User_controls
{
    /// <summary>
    /// Interação lógica para ToolBar.xam
    /// </summary>
    public partial class ToolBar : UserControl, INotifyPropertyChanged
    {
        public ToolBar()
        {
            InitializeComponent();
        }




        public ICommand OpenDrawer
        {
            get { return (ICommand)GetValue(OpenDrawerProperty); }
            set { SetValue(OpenDrawerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenDrawer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenDrawerProperty =
            DependencyProperty.Register("OpenDrawer", typeof(ICommand), typeof(ToolBar), new PropertyMetadata(null));




        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set
            {

                SetValue(FilterProperty, value);
                NotifyPropertyChanged();
            }
        }

        // Using a DependencyProperty as the backing store for Filter.  This enables animation, styling, binding, etc...
        public static DependencyProperty FilterProperty =
            DependencyProperty.Register("Filter", typeof(string), typeof(ToolBar), new PropertyMetadata("", OnFilterChanged));


        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ToolBar obj = d as ToolBar;
            obj.OnFilterChanged(e);
        }

        /// <summary>
        /// Reletindo a altearção via xaml na instancia
        /// </summary>
        /// <param name="e"></param>
        private void OnFilterChanged(DependencyPropertyChangedEventArgs e)
        {
            Filter = (string)e.NewValue;


        }

        public int FilterWidth
        {
            get { return (int)GetValue(FilterWidthProperty); }
            set { SetValue(FilterWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterWidthProperty =
            DependencyProperty.Register("FilterWidth", typeof(int), typeof(ToolBar), new PropertyMetadata(100));

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event alerting the WPF Framework to update the UI.
        /// </summary>
        /// <param name="propertyName">The optional name of the property to update in the View. If this is left blank, the name will be taken from the calling member via the CallerMemberName attribute.</param>
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
