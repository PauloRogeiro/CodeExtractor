using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MvvmFramework;



namespace app.design
{

    public class MainWindowViewModelDesign : MainWindowViewModel
    {



        public MainWindowViewModelDesign(): base(new MenuListViewModelDesign())
        {


        }


    }
}
