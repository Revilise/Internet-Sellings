using internet_sellings.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace internet_sellings.classes
{
    public class WindowFabric
    {
        static public Window CreateWindow(string userRole)
        {
            Window window;
            switch (userRole)
            {
                case "admin": window = new AdminWindow();
                    break;
                default: throw new Exception("Unexpected user role: "+userRole);
            }
            return window;
        }
    }
}
