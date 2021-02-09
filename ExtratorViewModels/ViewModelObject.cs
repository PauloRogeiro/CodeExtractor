using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Objects;

namespace ExtractorUI
{
    public class ViewModelObject : ObservableObject
    {
        private Menu _displayMenu;

        public Menu DisplayMenu { get => _displayMenu; set => SetProperty<Menu>(ref _displayMenu, value); }

        public ICollection<ViewModelObject> Filhos = new List<ViewModelObject>();

        public ViewModelObject(Menu menu)
        {
            DisplayMenu = menu;

        }
    }
}
