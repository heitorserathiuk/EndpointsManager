using EndpointsManager.Interface;
using System;

namespace EndpointsManager.Listener
{
    public class DefaultListener : MenuListener
    {
        public void selectedMenuOption(int option)
        {
            Console.WriteLine("You selected option  " + option);
            Console.WriteLine("\n");
        }
    }
}
