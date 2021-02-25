using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Toolkit.Mvvm.ComponentModel;
 

namespace app
{
    public class ProcessamentoContabilViewModel : ViewModelObject

    {

        private String _texto;

        public string Texto
        {
            get => _texto;
            set => SetProperty<String>(ref _texto, value);
        }

    }
}
