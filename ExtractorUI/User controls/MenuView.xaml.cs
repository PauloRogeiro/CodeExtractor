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

namespace app
{
    /// <summary>
    /// Interação lógica para MenuView.xam
    /// </summary>
    public partial class MenuView : UserControl
    {
        private String _menuText;
        private int _nivel;
        private String _icon;
        private String _action;
        private Thickness _textMargin;
        private int _offSet;
        private String _groupName;


        public MenuView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento de alteração da view via xaml
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnMenuTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuView obj = d as MenuView;


            obj.OnMenuTextChanged(e);
        }

        /// <summary>
        /// Evento de alteração de view no objeto local
        /// </summary>
        /// <param name="e"></param>
        private void OnMenuTextChanged(DependencyPropertyChangedEventArgs e)
        {

            if (_nivel==0)
            {
                String t = (String)e.NewValue;
                string[] l = t.Split(".");
                _nivel = l.Length;

            }

            //Retorna o último menu do agrupamento
            string[] list = e.NewValue.ToString().Split(".");
            MenuText = list[list.Length - 1]; ;
        }


        public String MenuText
        {
            get
            {
                return (String)GetValue(MenuTextProperty);
            }
            set { SetValue(MenuTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static DependencyProperty MenuTextProperty =
            DependencyProperty.Register("MenuText", typeof(String), typeof(MenuView), new PropertyMetadata(null, OnMenuTextChanged));

        public String Icon
        {
            get { return (String)GetValue(IConProperty); }
            set { SetValue(IConProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IConProperty =
            DependencyProperty.Register("Icon", typeof(String), typeof(MenuView), new PropertyMetadata(null));

        public String Action
        {
            get { return (String)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(String), typeof(MenuView), new PropertyMetadata(null));



        /// <summary>
        /// Evento de alteração da view via xaml
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnTextMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuView obj = d as MenuView;
            obj.OnTextMarginChanged(e);
        }

        /// <summary>
        /// Evento de alteração de view no objeto local
        /// </summary>
        /// <param name="e"></param>
        private void OnTextMarginChanged(DependencyPropertyChangedEventArgs e)
        {

            if (e.NewValue == null)
            {
                return;
            }


            TextMargin = (Thickness)e.NewValue ;


        }


        public Thickness TextMargin
        {
            get
            {

                return (Thickness)GetValue(TextMarginProperty);
            }
            set { SetValue(TextMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(MenuView), new PropertyMetadata(new Thickness(0,0,0,0), OnTextMarginChanged));



        /// <summary>
        /// Evento de alteração da view via xaml
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuView obj = d as MenuView;
            obj.OnOffsetChanged(e);
        }

        /// <summary>
        /// Evento de alteração de view no objeto local
        /// </summary>
        /// <param name="e"></param>
        private void OnOffsetChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            int off = (int)e.NewValue;
            //Desloca o texto do menu em relação ao seu pai
            Thickness ctxMargin = TextMargin;
            Thickness newMargin = new Thickness(ctxMargin.Left + (_nivel * off), ctxMargin.Top, ctxMargin.Right, ctxMargin.Bottom);
            TextMargin = newMargin;


        }


        public int Offset
        {
            get { return (int)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static DependencyProperty OffsetProperty =
            DependencyProperty.Register("Offset", typeof(int), typeof(MenuView), new PropertyMetadata(0, OnOffsetChanged));





        public String GroupName
        {
            get
            {

                return (String)GetValue(GroupNameProperty);
            }
            set { SetValue(GroupNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register("GroupName", typeof(string), typeof(MenuView), new PropertyMetadata(null));



        public String GroupValue
        {
            get
            {

                return (String)GetValue(GroupValueProperty);
            }
            set { SetValue(GroupValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupValueProperty =
            DependencyProperty.Register("GroupValue", typeof(string), typeof(MenuView), new PropertyMetadata(null));



        public bool CollapseComponent
        {
            get
            {
               
                return (bool)GetValue(CollapseComponentProperty);
            }
            set { SetValue(CollapseComponentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CollapseComponentProperty =
            DependencyProperty.Register("CollapseComponent", typeof(bool), typeof(MenuView), new PropertyMetadata(false));



        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static  DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MenuView), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}
