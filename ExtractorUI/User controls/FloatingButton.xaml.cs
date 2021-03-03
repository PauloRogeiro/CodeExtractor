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
    /// Interação lógica para FloatingButton.xam
    /// </summary>
    public partial class FloatingButton : UserControl
    {
        public FloatingButton()
        {
            InitializeComponent();
        }




        public ICommand Action
        {
            get { return (ICommand)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Action.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(ICommand), typeof(FloatingButton), new PropertyMetadata(null));


    }
}
