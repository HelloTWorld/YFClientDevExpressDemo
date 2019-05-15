using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YFClientDevExpressDemo.MenuLoad
{
    class Menu
    {
        public int ID { get; set; }

        public int ParentID { get; set; }

        public string Name { get; set; }

        public List<Menu> ChildMenus { get; set; }

        public int xh { get; set; }


        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="menuList"></param>
        public void AddChildMenus(List<Menu> menuList)
        {
            // 读取菜单列表中父id为此菜单的项
            ChildMenus = menuList.Where(u => u.ParentID == ID).ToList();

            //ChildMenus.ForEach(u =>
            //{
            //    menuList.Remove(u);
            //});

            // 遍历子菜单，循环加载子菜单的子菜单
            ChildMenus.ForEach(u =>
            {
                u.AddChildMenus(menuList);
            });
        }
    }
}
