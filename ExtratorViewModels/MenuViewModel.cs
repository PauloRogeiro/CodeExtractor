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


        private String _Texto;
        private String _Icone;
        private String _action;
        private String _group;
        private MenuListViewModel _menuList;

        //COmmands
        private ICommand _selected; 

        public string Text { get => _Texto; set => _Texto = value; }
        public string Icone { get => _Icone; set => _Icone = value; }
        public string Action { get => _action; set => _action = value; }
        public string Group { get => _group; set => _group = value; }

        private MenuListViewModel _menuListViewModel;


        public MenuViewModel(MenuListViewModel menuList,  string text = null, string icone = null, string action = null, string group =null)
        {
      
            _Texto = text;
            _Icone = icone;
            _action = action;
            _menuList = menuList;
            _group = group;
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
