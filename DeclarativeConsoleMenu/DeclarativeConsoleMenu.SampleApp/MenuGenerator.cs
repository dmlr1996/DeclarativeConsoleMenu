﻿using System;

namespace DeclarativeConsoleMenu.SampleApp
{
    class MenuGenerator
    {
        public static MenuCollection CreateMenuCollection()
        {
            MenuCollection collection = new MenuCollection();

            //Declarative way of building a menu, there are also generator methods you can use.
            return new MenuCollection()
            {
                Menus = {
                    new Menu()
                    {
                        // give the menu an identifier
                        MenuId = 1,
                        MenuItems =
                        {
                            new MenuItem()
                            {
                                Text = "Open Sub Menu",
                                // if you want to link to another menu, then set the other menu's id
                                SubMenuId = 2
                            },
                            new MenuItem()
                            {
                                Text = "Print hello world!",
                                //or if you want to perform an action, set the Action property
                                FirstAction = () => Console.WriteLine("Hello World!"),
                                SubMenuId = 1
                            }
                        }
                    },
                    new Menu()
                    {
                        MenuId = 2,
                        MenuItems =
                        {
                            new MenuItem()
                            {
                                Text = "Print Hello",
                                FirstAction = () => Console.WriteLine("Hello"),
                                SubMenuId = 2
                            },
                            new MenuItem()
                            {
                                Text = "Print Goodbye",
                                FirstAction = () => Console.WriteLine("Goodbye"),
                                SecondAction = () => Console.WriteLine("SecondAction"),
                                SubMenuId = 2
                            },
                            new MenuItem()
                            {
                                Text = "Back to the top menu",
                                SubMenuId = 1
                            }
                        }
                    }
                }
            };
        }
    }
}
