using System;
using System.Collections.Generic;
using System.Text;


namespace app.design
{
    public class DesignMenuVewModel
    {

        public readonly String Nome = "Contabil";
        public readonly String Texto = "Contabil";
        public readonly String Icone = "AccountCircle"; 
        public readonly String View = "ContabilView";


    public DesignMenuVewModel()
        {

        }

        public Menu GetMenu() {

            return new Menu() { Nome = this.Nome, Icone = this.Icone, Texto = this.Texto, View = this.View };
        
        }

    }
}
