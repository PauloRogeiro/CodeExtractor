using System;
using DataService;
using Objects;
using System.Collections.Generic;

namespace BusinessObjects
{
    public class MenuRepository : IMenuRepository
    {

        private IDataSource<Menu> _dataSource;

        public IEnumerable<Menu> Menus
        {
            private set { }

            get => _dataSource.GetALL();

        }


        public MenuRepository(IDataSource<Menu> data)
        {
            _dataSource = data;
        }

        public void AdicionarMenu(Menu menu)
        {
            _dataSource.Add(menu);
        }

        public void Commit()
        {
            _dataSource.CommitChanges();
        }

        public IEnumerable<Menu> GetAllMenus()
        {

            return _dataSource.GetALL();
        }

        public void SalvarMenus(IEnumerable<Menu> menus)
        {

            _dataSource.CommitAll(menus);
        }


    }
}
