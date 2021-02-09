using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Objects; 

namespace ExtractorUI
{
    public class ProcessamentoContabilViewModel : ViewModelObject

    {

        private String _texto;

        public string Texto
        {
            get => _texto;
            set => SetProperty<String>(ref _texto, value);
        }

        public ProcessamentoContabilViewModel() : base(new Menu { Name ="Processmento contábil"})        {
            _texto = "Its Works";
        }
    }
}
