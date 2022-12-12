using System;
using System.Collections.Generic;
using System.Linq;

namespace DeclarativeConsoleMenu
{
    public sealed class MenuCollection
    {
        public bool ClearConsoleScreen = true;

        public MenuCollection()
        {
            Menus = new List<Menu>();
        }

        public List<Menu> Menus { get; set; }

        public void AddMenu(Menu menu)
        {
            Menus.Add(menu);
        }

        public void ShowMenu(int id)
        {
            //get the menu we want to display and call its PrintToConsole method
            var currentMenu = Menus.Single(m => m.MenuId == id);
            currentMenu.PrintToConsole();

            //wait for user input
            string choice = Console.ReadLine();

            // once we have the users selection make sure its an integer and in range of our menu options
            if (!int.TryParse(  choice, out var choiceIndex) || choiceIndex < 0 || choiceIndex >= currentMenu.MenuItems.Count )
            {
                if (ClearConsoleScreen)
                {
                    Console.Clear();
                }

                // Redisplay menu with error message.
                Console.WriteLine("Invalid selection - try again");
                ShowMenu(id);
            }
            else
            {
                // Retrieve the corresponding menu item
                var menuItemSelected = currentMenu.MenuItems[choiceIndex];

                // if there's a sub menu then display it
                if (menuItemSelected.SubMenuId.HasValue)
                {
                    if (ClearConsoleScreen)
                    {
                        Console.Clear();
                    }
                    menuItemSelected.FirstAction?.Invoke();
                    menuItemSelected.SecondAction?.Invoke();
                    ShowMenu(menuItemSelected.SubMenuId.Value);
                }
                // otherwise perform whatever action we need
                else
                {
                    menuItemSelected.FirstAction?.Invoke();
                    menuItemSelected.SecondAction?.Invoke();
                }
            }
        }
    }
}
