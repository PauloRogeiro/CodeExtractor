using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmFramework;
using System.Collections.ObjectModel;


namespace app.design
{
    public class CardListViewModelDesign : CardListViewModel
    {


        public CardListViewModelDesign() : base( )
        {

            Cards.Add(new CardViewModelDesign());
            Cards.Add(new CardViewModelDesign());
            Cards.Add(new CardViewModelDesign());

            
        }



      
    }
}
