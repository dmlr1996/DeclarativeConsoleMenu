using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeConsoleMenu
{
    public class MenuItem
    {
        // displayed in the menu
        public virtual string Text { get; set; }

        // if there's a submenu, what's its id
        public virtual int? SubMenuId { get; set; }

        //if there isn't a sub menu, what should we do
        public virtual Action FirstAction { get; set; }
        public virtual Action SecondAction { get; set; }

        public static MenuItem CreateWithAction(string title, Action firstAction)
        {
            return new MenuItem()
            {
                Text = title,
                FirstAction = firstAction
            };
        }

        public static MenuItem CreateWithSecondAction(string title, Action firstAction, Action secondAction)
        {
            return new MenuItem()
            {
                Text = title,
                FirstAction = firstAction,
                SecondAction = secondAction
            };
        }

        public static MenuItem CreateWithSubMenu(string title, int subMenuId)
        {
            return new MenuItem()
            {
                Text = title,
                SubMenuId = subMenuId
            };
        }

        public static MenuItem CreateWithActionAndSubMenu(string title, Action firstAction, int subMenuId)
        {
            return new MenuItem()
            {
                Text = title,
                FirstAction = firstAction,
                SubMenuId = subMenuId
            };
        }
    }
}
