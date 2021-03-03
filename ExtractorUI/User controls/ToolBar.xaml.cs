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

namespace app.User_controls
{
    /// <summary>
    /// Interação lógica para ToolBar.xam
    /// </summary>
    public partial class ToolBar : UserControl
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
            set { SetValue(FilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Filter.  This enables animation, styling, binding, etc...
        public static  DependencyProperty FilterProperty =
            DependencyProperty.Register("Filter", typeof(string), typeof(ToolBar), new PropertyMetadata(null));




        public int FilterWidth
        {
            get { return (int)GetValue(FilterWidthProperty); }
            set { SetValue(FilterWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterWidthProperty =
            DependencyProperty.Register("FilterWidth", typeof(int), typeof(ToolBar), new PropertyMetadata(100));




    }
}
