using System;
using System.Collections.Generic;
using app;

namespace app.design
{
    public class DesigMenuListViewModel
    {

        private List<Menu> _menus = new List<Menu>() { new DesignMenuVewModel().GetMenu() };


        public List<Menu> Menus
        {
            get => _menus;
           
        }

      
    }
}
