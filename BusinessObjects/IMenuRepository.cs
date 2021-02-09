using System.Collections.Generic;
using Objects;

namespace BusinessObjects
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetAllMenus();
        void SalvarMenus(IEnumerable<Menu> menus);
        void AdicionarMenu(Menu menu);
        void Commit();
    }
}