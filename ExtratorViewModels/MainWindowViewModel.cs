using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MvvmFramework;



namespace app
{

    public class MainWindowViewModel : ObservableObject
    {


        protected int _selectedIndex;
        protected MenuListViewModel _menuVM;


        protected ICollection<ViewModelObject> _models;
        protected ViewModelObject _selectedModel;



        public MainWindowViewModel(String menuXMl, MenuListViewModel menus) : base()
        {

            _menuVM = menus;
            _menuVM.PropertyChanged += MenuChanged;
            _models = new ObservableCollection<ViewModelObject>(GerarModels());


        }




        private void MenuChanged(object sender, PropertyChangedEventArgs e)
        {

            MenuViewModel changedMenu = ((MenuListViewModel)sender).SelectedMenu;

            if (changedMenu == null)
            {
                return;
            }

            String viewName = this.GetType().Namespace + "." + changedMenu.View.ToString().Replace("View", "ViewModel");
            SelectedModel = IoC.Get<ViewModelObject>(viewName);




        }

        public ViewModelObject SelectedModel
        {
            get => _selectedModel;
            set
            {
                SetProperty<ViewModelObject>(ref _selectedModel, value);

            }
        }


        public ICollection<ViewModelObject> Models
        {

            private set => SetProperty<ICollection<ViewModelObject>>(ref _models, value);
            get => _models;


        }



        public int SelectedIndex
        {
            set
            {

                SetProperty<int>(ref _selectedIndex, value);


            }
            get { return _selectedIndex; }
        }

        public MenuListViewModel MenuVM
        {
            get => _menuVM;
        }

        private IEnumerable<ViewModelObject> GerarModels()
        {
            yield return new ContabilViewModel();


            yield return new ProcessamentoContabilViewModel();

            //Adicionado filhos do menu contabil
            yield return new FiscalViewModel();

            //Adicionado filhos do menu contabil
           // yield return new CardViewModel();


        }




    }
}
