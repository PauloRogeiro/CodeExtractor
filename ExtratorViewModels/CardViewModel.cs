using System;
using System.Collections.Generic;
using System.Text;
using MvvmFramework;
using System.Windows.Input;


namespace app
{
    public class CardViewModel : ViewModelObject
    {

        private string _nome = "";
        private string _descricao = "";
        private String _icone = "CardTextOutline";
        private ICommand _save;

        private CardListViewModel _parentViewModel;

        public string Descricao
        {
            get => _descricao;
            set => SetProperty<String>(ref _descricao, value);
        }
        public string Nome
        {
            get => _nome;
            set => SetProperty<String>(ref _nome, value);
        }

        public string Icone
        {
            get => _icone;
            set => SetProperty<String>(ref _icone, value);
        }
        public CardListViewModel ParentViewModel { get => _parentViewModel; }
      
        
        public ICommand Save
        {
            get => _save;
            set => _save = value;
        }

        public CardViewModel(CardListViewModel cards)
        {
            _parentViewModel = cards;
            _save = new RelayCommand(SaveItem);
        }


        private void SaveItem() {

            this.Nome = Nome + "save";
        
        }




    }


}
