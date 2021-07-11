using EndpointsManager.Interface;
using System;
using System.Collections.Generic;

namespace EndpointsManager.Models
{
    public class Menu
    {
		private string title = "*** MENU ***";
		private string prompt = "Option: ";
		private string errorMessage = "Invalid option.";
		private List<Option> options = new List<Option>();

		public Menu()
        {
        }

        public Menu(string title)
        {
            this.title = title;
        }

        public void add(Option option)
        {
            options.Add(option);
            option.optionId = options.Count;
        }
        public void add(String title, MenuListener listener)
        {
            Option option = new Option(title, listener);
            add(option);
        }

        public void add(String title, MenuListener listener, bool exit)
        {
            Option option = new Option(title, listener, exit);
            add(option);
        }

		public void show()
		{
			while (true)
			{
				try
				{
					StartMenu();
					int op = Convert.ToInt32(Console.ReadLine());
					if (op > 0 && op <= options.Count)
					{
						Option option = options[op - 1];
						option.activate();
						if (option.exit)
						{
							break;
						}
					}
					else
					{
						Console.WriteLine(errorMessage);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(errorMessage);
				}
			}
		}
		
		public void StartMenu()
		{
			string menuText = string.Concat(title,"\n\n");
			foreach (Option op in options)
			{
				menuText += string.Concat(op.title, "\n");;
			}
			menuText += string.Concat("\n", prompt);
			Console.WriteLine(menuText);
		}
	}
}
