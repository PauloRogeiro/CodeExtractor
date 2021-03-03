using System;
using System.Collections.Generic;
using System.Text;


namespace app.design
{
    public class DesignMenuVewModel
    {


        public readonly String Text = "Contabil";
        public readonly String Icone = "AccountCircle"; 
        public readonly String Action = "ContabilView";


    public DesignMenuVewModel()
        {

        }

        public Menu GetMenu() {

            return new Menu() {  Icone = this.Icone, Text = this.Text, Action = this.Action };
        
        }

    }
}
