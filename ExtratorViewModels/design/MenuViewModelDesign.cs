using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using MvvmFramework;


namespace app.design
{
    public class MenuViewModelDesign : MenuViewModel
    {

        public MenuViewModelDesign():base(new MenuListViewModelDesign(),"Menu1","AccountOutline","MenuListView")
        {

        }
    }
}
