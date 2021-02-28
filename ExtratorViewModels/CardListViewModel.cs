using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmFramework;
using System.Collections.ObjectModel;

namespace app
{
    public class CardListViewModel : ViewModelObject
    {


        private ObservableCollection<CardViewModel> _cards;


        private ICommand _add;



        public CardListViewModel()
        {
            _add = new RelayCommand(AddNew);
            _cards = new ObservableCollection<CardViewModel>();
            _cards.Add(new CardViewModel(this) { Nome = "add", Descricao="", Icone= "PlusThick" });
            _cards.Add( new CardViewModel(this) { Nome = "card1", Descricao = "descrição muito longa" } );
            _cards.Add(new CardViewModel(this) { Nome = "card1", Descricao = "descrição curta" });

        } 

        public ObservableCollection<CardViewModel> Cards
        {
            get => _cards;
            set => SetProperty<ObservableCollection<CardViewModel>>(ref _cards, value);
        }
        public ICommand Add { get => _add; }
        


        public void AddNew()
        {
 
            _cards.Add( new CardViewModel(this));
        }



      
    }
}
