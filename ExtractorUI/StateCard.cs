using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives ;
using System.Windows.Input;
using MvvmFramework;
using System.Reflection;

namespace app
{
    public class StateCard : ContentControl
    {

        private ItemsControl _container;
        private ICommand _remove;
        private ICommand _onSave;
        private ICommand _onRemove;
        private ICommand _onEdit;
        private object _selectedItem;


        public StateCard()
        {
            _remove = new RelayCommand(RemoveItem);

        }


        static StateCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StateCard), new FrameworkPropertyMetadata(typeof(StateCard)));
        }

        /// <summary>
        /// Property xaml do estado de visualização
        /// </summary>
        public static readonly DependencyProperty
               ViewStateProperty = DependencyProperty.Register("ViewState", typeof(Control),
               typeof(Control), new FrameworkPropertyMetadata(null,
               new PropertyChangedCallback(OnViewStateChanged)));

        /// <summary>
        /// Propriedade estado de visualização
        /// </summary>
        public Control ViewState
        {
            get { return (ContentControl)GetValue(ViewStateProperty); }
            set { SetValue(ViewStateProperty, value); }
        }

        /// <summary>
        /// Evento de alteração da view via xaml
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnViewStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateCard card = d as StateCard;
            card.OnViewStateChanged(e);
        }

        /// <summary>
        /// Evento de alteração de view no objeto local
        /// </summary>
        /// <param name="e"></param>
        private void OnViewStateChanged(DependencyPropertyChangedEventArgs e)
        {
            ViewState = (Control)e.NewValue;
        }

        /// <summary>
        /// Property xaml
        /// </summary>
        public static readonly DependencyProperty
               EditStateProperty = DependencyProperty.Register("EditState", typeof(Control),
               typeof(Control), new FrameworkPropertyMetadata(null,
               new PropertyChangedCallback(OnEditStateChanged)));

        public Control EditState
        {
            get { return (Control)GetValue(EditStateProperty); }
            set { SetValue(EditStateProperty, value); }
        }

        private static void OnEditStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateCard card = d as StateCard;
            card.OnEditStateChanged(e);
        }

        private void OnEditStateChanged(DependencyPropertyChangedEventArgs e)
        {
            EditState = (ContentControl)e.NewValue;
        }


        /// <summary>
        /// Registra os handles das ações de viewModel nos butões devidos
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button btn = Template.FindName("SaveButton", this) as Button;
            ToggleButton btnClose = Template.FindName("CloseButton", this) as ToggleButton;
            Button btnEdit = Template.FindName("EditButton", this) as Button;
            btn.Click += new RoutedEventHandler(SaveAction);
            btnClose.Click += new RoutedEventHandler(RemoveAction);
            btnEdit.Click += new RoutedEventHandler(EditAction);

        }


        /// <summary>
        /// Adiciona a proriedade de model selecionado no Xaml
        /// </summary>
        public static DependencyProperty SelectedProperty =
                    DependencyProperty.Register(
                    "Selected", typeof(object), typeof(StateCard),
                    new FrameworkPropertyMetadata(null,
                   new PropertyChangedCallback(OnSelectedChanged)));


        /// <summary>
        /// Indica que a propriedade selected foi alterada via xaml
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateCard obj = d as StateCard;
            obj.OnSelectedChanged(e);
        }


        /// <summary>
        /// Preenche a propriedade selected com o valor passado via xaml
        /// </summary>
        /// <param name="e"></param>
        private void OnSelectedChanged(DependencyPropertyChangedEventArgs e)
        {
            Selected = e.NewValue;


        }

        /// <summary>
        /// Registra o comportamento de Salvar do viewModel no botao de salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAction(object sender, EventArgs e) {
            if (_onSave != null)
            {
                _onSave.Execute(e);
            }
        }

        /// <summary>
        /// Registra o comportamento de Salvar do viewModel no botao de salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditAction(object sender, EventArgs e)
        {
            if (_onEdit != null)
            {
                _onEdit.Execute(e);
            }
        }

        /// <summary>
        /// Registra o comportamento de Salvar do viewModel no botao de salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAction(object sender, EventArgs e)
        {
            if (_onRemove != null)
            {
                _onRemove.Execute(e);
            }
        }



        /// <summary>
        /// Seta o objeto atual da viewModel como selecionado.
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
        /// Implementação da ação de remover
        /// Essa ação exclui um objeto viewModel da lista observada
        /// </summary>
        public ICommand Remove
        {

            get
            {

                return _remove;
            }
        }



        /// <summary>
        /// Remove um objeto view model da lista, como consequência o controle dela não é renderizado
        /// </summary>
        private void RemoveItem()
        {
            //Items control pai do controle
            if (_container == null)
            {
                return;
            }

            //View model object
            if (DataContext == null)
            {
                return;
            }

            //Remove o view model via reflexão
            Type t = _container.ItemsSource.GetType();
            MethodInfo m = t.GetMethod("Remove");
            m.Invoke(_container.ItemsSource, new object[] { Selected });
        }



        /// <summary>
        /// Property xaml
        /// </summary>
        public static DependencyProperty ListContainerProperty =
                DependencyProperty.Register(
                "ListContainer", typeof(ItemsControl), typeof(StateCard),
                new FrameworkPropertyMetadata(null,
               new PropertyChangedCallback(OnListContainerChanged)));


        /// <summary>
        /// Alteração do itemsControl via xaml
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnListContainerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateCard obj = d as StateCard;
            obj.OnListContainerChanged(e);
        }

        /// <summary>
        /// Reletindo a altearção via xaml na instancia
        /// </summary>
        /// <param name="e"></param>
        private void OnListContainerChanged(DependencyPropertyChangedEventArgs e)
        {
            ListContainer = (ItemsControl)e.NewValue;

        }

        /// <summary>
        /// Items control pai do controle card
        /// </summary>
        public ItemsControl ListContainer
        {
            get => _container;
            set => _container = value;
        }

        

        /// <summary>
        /// Property xaml
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty =
                DependencyProperty.Register(
                "SelectedItem", typeof(Object), typeof(StateCard),
                new FrameworkPropertyMetadata(null,
               null));

        public Object SelectedItem
        {

            get => _selectedItem;
            set => _selectedItem = value;
        }

        /// <summary>
        /// Property OnSave para vinculo via xaml
        /// </summary>
        public readonly static DependencyProperty OnSaveProperty =
                DependencyProperty.Register(
                "OnSave", typeof(ICommand), typeof(StateCard),
                new FrameworkPropertyMetadata(
               new PropertyChangedCallback(OnSaveChanged)));

   
        /// <summary>
        /// Repassa o comportamento de salvar para a instancia
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnSaveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateCard obj = d as StateCard;
            obj.OnSaveChanged(e);
        }

        /// <summary>
        /// Reflete a alteração de salvar na instância atual
        /// </summary>
        /// <param name="e"></param>
        private void OnSaveChanged( DependencyPropertyChangedEventArgs e)
        {
            OnSave = (ICommand)e.NewValue;
        }


        /// <summary>
        /// Retorna o comportamento customizado da ação de salvar
        /// </summary>
        public ICommand OnSave
        {
            get => _onSave;
            set => _onSave = value;
        }




        /// <summary>
        /// Property OnEdit para vinculo via xaml
        /// </summary>
        public readonly static DependencyProperty OnEditProperty =
                DependencyProperty.Register(
                "OnEdit", typeof(ICommand), typeof(StateCard),
                new FrameworkPropertyMetadata(
               new PropertyChangedCallback(OnEditChanged)));


        /// <summary>
        /// Repassa o comportamento de Editar para a instancia
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnEditChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateCard obj = d as StateCard;
            obj.OnEditChanged(e);
        }

        /// <summary>
        /// Reflete a alteração de salvar na instância atual
        /// </summary>
        /// <param name="e"></param>
        private void OnEditChanged(DependencyPropertyChangedEventArgs e)
        {
            OnEdit = (ICommand)e.NewValue;
        }


        /// <summary>
        /// Retorna o comportamento customizado da ação de Editar
        /// </summary>
        public ICommand OnEdit
        {
            get => _onEdit;
            set => _onEdit = value;
        }


        /// <summary>
        /// Property OnEdit para vinculo via xaml
        /// </summary>
        public readonly static DependencyProperty OnRemoveProperty =
                DependencyProperty.Register(
                "OnRemove", typeof(ICommand), typeof(StateCard),
                new FrameworkPropertyMetadata(
               new PropertyChangedCallback(OnRemoveChanged)));


        /// <summary>
        /// Repassa o comportamento de Editar para a instancia
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnRemoveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateCard obj = d as StateCard;
            obj.OnRemoveChanged(e);
        }

        /// <summary>
        /// Reflete a alteração de salvar na instância atual
        /// </summary>
        /// <param name="e"></param>
        private void OnRemoveChanged(DependencyPropertyChangedEventArgs e)
        {
            OnRemove = (ICommand)e.NewValue;
        }


        /// <summary>
        /// Retorna o comportamento customizado da ação de Editar
        /// </summary>
        public ICommand OnRemove
        {
            get => _onRemove;
            set => _onRemove = value;
        }



        /// <summary>
        /// Seta a propriedade selectedItem a partir de um objeto da lista do viewModel
        /// </summary>
        /// <param name="obj"></param>
        public void SetSelected(Object obj)
        {

            this.SelectedItem = obj;

        }





    }
}
