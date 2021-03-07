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
