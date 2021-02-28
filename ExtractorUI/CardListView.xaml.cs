using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
    
namespace app
{
    /// <summary>
    /// Interação lógica para CardListView.xam
    /// </summary>
    public partial class CardListView : UserControl
    {
        

        public CardListView()
        {
            InitializeComponent();

        }

        // Find a descendant control by name.
        private static DependencyObject FindDescendant(
            DependencyObject parent, string name)
        {
            // See if this object has the target name.
            FrameworkElement element = parent as FrameworkElement;
            if ((element != null) && (element.Name == name)) return parent;

            // Recursively check the children.
            int num_children = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < num_children; i++)
            {
                // See if this child has the target name.
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                DependencyObject descendant = FindDescendant(child, name);
                if (descendant != null) return descendant;
            }

            // We didn't find a descendant with the target name.
            return null;
        }


    }
}
