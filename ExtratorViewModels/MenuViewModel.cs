using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using MvvmFramework;


namespace app
{
    public class MenuViewModel : ObservableObject
    {

        private String _nome;
        private String _Texto;
        private String _Icone;
        private String _view;
        private MenuListViewModel _menuList;

        //COmmands
        private ICommand _selected; 

        public string Nome { get => _nome; set => _nome = value; }
        public string Texto { get => _Texto; set => _Texto = value; }
        public string Icone { get => _Icone; set => _Icone = value; }
        public string View { get => _view; set => _view = value; }

        private MenuListViewModel _menuListViewModel;


        public MenuViewModel(MenuListViewModel menuList, string nome = null, string texto = null, string icone = null, string view = null)
        {
            _nome = nome;
            _Texto = texto;
            _Icone = icone;
            _view = view;
            _menuList = menuList;
            _selected = new RelayCommand(SetSelected);
        }
        /// <summary>
        /// preenchendo o menuLisviewModel
        /// </summary>
        public MenuListViewModel MenuListViewModel
        {
            get => _menuListViewModel;
            set => SetProperty<MenuListViewModel>(ref _menuListViewModel, value) ;
        }
        public ICommand Selected { get => _selected; set => _selected = value; }

        public void SetSelected() {

            _menuList.SelectedMenu = this;
        }
        
    }
}
