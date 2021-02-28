using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MvvmFramework;
using System.Reflection;

namespace app
{
    public class AppCard : ContentControl
    {

        private ItemsControl _container;
        private ICommand _remove;
        private object _selectedItem;
        private System.Collections.IEnumerable _models;

        public AppCard()
        {
            _remove = new RelayCommand(RemoveItem);

        }


        static AppCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AppCard), new FrameworkPropertyMetadata(typeof(AppCard)));
        }

        /// <summary>
        /// Property xaml
        /// </summary>
        public static readonly DependencyProperty
               CardViewProperty = DependencyProperty.Register("CardView", typeof(Control),
               typeof(Control), new FrameworkPropertyMetadata(null,
               new PropertyChangedCallback(OnCardViewChanged)));

        /// <summary>
        /// Propriedade do presenter
        /// </summary>
        public Control CardView
        {
            get { return (ContentControl)GetValue(CardViewProperty); }
            set { SetValue(CardViewProperty, value); }
        }

        /// <summary>
        /// Evento de alteração da view via xaml
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCardViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AppCard card = d as AppCard;
            card.OnCardViewChanged(e);
        }

        /// <summary>
        /// Evento de alteração de view no objeto local
        /// </summary>
        /// <param name="e"></param>
        private void OnCardViewChanged(DependencyPropertyChangedEventArgs e)
        {
            CardView = (Control)e.NewValue;
        }

        /// <summary>
        /// Property xaml
        /// </summary>
        public static readonly DependencyProperty
               CardEditViewProperty = DependencyProperty.Register("CardEditView", typeof(Control),
               typeof(Control), new FrameworkPropertyMetadata(null,
               new PropertyChangedCallback(OnCardEditViewChanged)));

        public Control CardEditView
        {
            get { return (Control)GetValue(CardEditViewProperty); }
            set { SetValue(CardEditViewProperty, value); }
        }

        private static void OnCardEditViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AppCard card = d as AppCard;
            card.OnCardEditViewChanged(e);
        }

        private void OnCardEditViewChanged(DependencyPropertyChangedEventArgs e)
        {
            CardEditView = (ContentControl)e.NewValue;
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

        }


        public static DependencyProperty SelectedProperty =
                    DependencyProperty.Register(
                    "Selected", typeof(object), typeof(AppCard),
                    new FrameworkPropertyMetadata(null,
                   new PropertyChangedCallback(OnSelectedChanged)));



        private static void OnSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AppCard obj = d as AppCard;
            obj.OnSelectedChanged(e);
        }

        private void OnSelectedChanged(DependencyPropertyChangedEventArgs e)
        {
            Selected = e.NewValue;

        }

        /// <summary>
        /// Seta o objeto selecionado no containner.
        /// </summary>
        public object Selected
        {

            set
            {
                if (DataContext == null)
                {
                    return;
                }

                SetSelected(DataContext);

            }
            get
            {
      
                return SelectedItem;

            }
        }

        /// <summary>
        /// Retorna o comando de remoção no containner.
        /// </summary>
        public ICommand Remove
        {

            get
            {

                return _remove;
            }
        }


        

        private void RemoveItem()
        {

            if (_container==null)
            {
                return;
            }

            if (DataContext == null)
            {
                return;
            }
            

            Type t = _container.ItemsSource.GetType();
            MethodInfo m = t.GetMethod("Remove");
            m.Invoke(_container.ItemsSource, new object[] { Selected });
        }



        /// <summary>
        /// Property xaml
        /// </summary>

        public static DependencyProperty ListContainerProperty =
                DependencyProperty.Register(
                "ListContainer", typeof(ItemsControl), typeof(AppCard),
                new FrameworkPropertyMetadata(null,
               new PropertyChangedCallback(OnListContainerChanged)));


        private static void OnListContainerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AppCard obj = d as AppCard;
            obj.OnListContainerChanged(e);
        }


        private void OnListContainerChanged(DependencyPropertyChangedEventArgs e)
        {
            ListContainer = (ItemsControl)e.NewValue;

        }


        public ItemsControl ListContainer
        {
            get => _container;
            set => _container = value;
        }

        /// <summary>
        /// Property xaml
        /// </summary>

        public static DependencyProperty ModelsProperty =
                DependencyProperty.Register(
                "Models", typeof(System.Collections.IEnumerable), typeof(AppCard),
                new FrameworkPropertyMetadata(
               new PropertyChangedCallback(OnModelsChanged)));

        public System.Collections.IEnumerable Models
        {

            get => _models;
            set => _models = value;
        }


        private static void OnModelsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AppCard obj = d as AppCard;
            obj.OnModelsChanged(e);
        }

        private void OnModelsChanged(DependencyPropertyChangedEventArgs e)
        {
            Models = (System.Collections.IEnumerable)e.NewValue;

        }


        /// <summary>
        /// Property xaml
        /// </summary>

        public static readonly DependencyProperty SelectedItemProperty =
                DependencyProperty.Register(
                "SelectedItem", typeof(Object), typeof(AppCard),
                new FrameworkPropertyMetadata(null,
               null));

        public Object SelectedItem
        {

            get => _selectedItem;
            set => _selectedItem = value;
        }


        /// <summary>
        /// Seta a propriedade selectedItem a partir de um objeto
        /// </summary>
        /// <param name="obj"></param>
        public void SetSelected(Object obj)
        {
   
            this.SelectedItem = obj;

        }

  



    }
}
