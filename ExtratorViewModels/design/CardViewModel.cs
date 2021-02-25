using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmFramework;

namespace app.design
{
    public class CardViewModel 
    {

        public static CardViewModel Instance = new CardViewModel();

        private string _nome;
        private string _descricao;
        private String _icone;
        private CardListViewModel _cards;

        private ICommand _remove;

        public string Descricao
        {
            get => _descricao;
            set => _descricao =value ;
        }
        public string Nome
        {
            get => _nome;
            set => _nome =value;
        }

        public string Icone
        {
            get => _icone;
            set => _icone = value;
        }
        
        public ICommand Remove { get => _remove;  }

        public CardViewModel()
        {
            _cards = new CardListViewModel();
            _nome = "Card 1";
            _descricao = "Essa é uma descrição longa";
            _icone = "AccountMusicOutline";

        }




    }


}
