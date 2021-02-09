using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;
using Objects;
using System.Runtime.CompilerServices;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using BusinessObjects;
using MvvmFramework;
using System.Windows.Data;



namespace ExtractorUI
{

    public class MainWindowViewModel : ViewModelObject
    {


        private int _selectedIndex;
        private String _textoPesquisado;
        private IMenuRepository _rep;


        private ICollection<ViewModelObject> _models;
        private ObservableCollection<Menu> _menus = new ObservableCollection<Menu>();
        private ViewModelObject _selectedModel;
        private Menu _selectedMenu;



        public MainWindowViewModel(IMenuRepository repository) : base(null)
        {
            _rep = repository;
            _models = new ObservableCollection<ViewModelObject>(GerarModels());
            GerarMenus();
            _rep.SalvarMenus(_menus);


        }
        public MainWindowViewModel() : base(null)
        {


        }



        public Menu SelectedMenu
        {
            get => _selectedMenu;
            set
            {
                SetProperty<Menu>(ref _selectedMenu, value);
                foreach (var item in _models)
                {
                    if (item.DisplayMenu.Name.Equals(_selectedMenu.Name))
                    {
                        SelectedModel = item;
                        break;
                    }
                }
            }
        }

        public ViewModelObject SelectedModel
        {
            get => _selectedModel;
            set => SetProperty<ViewModelObject>(ref _selectedModel, value);
        }


        public ICollection<ViewModelObject> Models
        {

            private set => SetProperty<ICollection<ViewModelObject>>(ref _models, value);
            get => _models;


        }

        public ObservableCollection<Menu> Menus
        {
            get => _menus;
            set => SetProperty<ObservableCollection<Menu>>(ref _menus, value);
        }
        public int SelectedIndex
        {
            set
            {

                SetProperty<int>(ref _selectedIndex, value);


            }
            get { return _selectedIndex; }
        }

        public String TextoPesquisado
        {
            set
            {
                SetProperty<String>(ref _textoPesquisado, value);

                _menus.Clear();
                //Inserindo itens filtrados
                GerarMenus();

            }
            get => _textoPesquisado;

        }



        private void GerarMenus()
        {
            foreach (var item in _models)
            {
                if (FilterByName(item.DisplayMenu))
                {
                    _menus.Add(item.DisplayMenu);
                }
            }

        }


        private IEnumerable<ViewModelObject> GerarModels()
        {
            ViewModelObject m;
            ICollection<ViewModelObject> filhos;
            yield return m = new ContabilViewModel();

            filhos = m.Filhos;
            yield return m = new ProcessamentoContabilViewModel();

            //Adicionado filhos do menu contabil
            filhos.Add(m);
            yield return m = new FiscalViewModel();



        }


        private bool FilterByName(Menu value)
        {

            if (String.IsNullOrEmpty(_textoPesquisado))
            {
                return true;
            }

            return value.Name.ToLower().Contains(_textoPesquisado);

        }

    }
}
