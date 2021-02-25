using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmFramework;

namespace app.design
{
    public class CardListViewModel
    {

        private List<CardViewModel> cards = new List<CardViewModel> {
            new CardViewModel() { Nome = "card1", Descricao = "descrição curta" }, new CardViewModel() { Nome = "card1", Descricao = "descrição muito longa" } };
        
        private ICommand _add;


        public CardListViewModel()
        {
            _add = new RelayCommand(Add);
        }

        public void Add()
        {

        }
    }
}
