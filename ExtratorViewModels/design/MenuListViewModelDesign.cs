using System;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Data;

namespace app.design
{
    public class MenuListViewModelDesign : MenuListViewModel
    {

        public static MenuListViewModelDesign Instance = new MenuListViewModelDesign();


        public MenuListViewModelDesign() : base()
        {
            Menus.Add(new MenuViewModelDesign());
        }

    }

}
