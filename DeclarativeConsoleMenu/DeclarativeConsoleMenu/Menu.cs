using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeConsoleMenu
{
    public sealed class Menu
    {
        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }

        public int MenuId { get; set; }

        public List<MenuItem> MenuItems { get; set; }

        public string Title { get; set; }

        public void PrintToConsole()
        {
            foreach (MenuItem item in MenuItems)
            {
                Console.WriteLine(MenuItems.IndexOf(item) + " : " + item.Text);
            }
        }

        public static Menu Create(int id, string title)
        {
            return new Menu()
            {
                Title = title,
                MenuId = id
            };
        }

        public static Menu Create(int id, string title, IEnumerable<MenuItem> menuItems)
        {
            Menu menu = new Menu()
            {
                Title = title,
                MenuId = id
            };

            menu.MenuItems.AddRange(menuItems);

            return menu;
        }

        public static Menu Create(int id, string title, params MenuItem[] menuItems)
        {
            return Create(id, title, menuItems);
        }
    }
}
