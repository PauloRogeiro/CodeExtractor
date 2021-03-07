using System;
using System.Collections.Generic;
using System.Text;
using MvvmFramework;
using System.Windows.Input;


namespace app.design
{
    public class CardViewModelDesign : CardViewModel
    {



        public CardViewModelDesign():base(new CardListViewModelDesign())
        {
            Descricao = "Menu 1";
            Icone = "AccountOUtline";
            Nome= "Menu 1";
            


        }

    }


}
