using EndpointsManager.Interface;
using EndpointsManager.Listener;
using EndpointsManager.Models;

namespace EndpointsManager
{
    public class Program
    {
		public static Context context = new Context();
		private static MenuListener defaultListener = new DefaultListener();
		private static MenuListener insertListener = new InsertListener();
		private static MenuListener editListener = new EditListener();
		private static MenuListener deleteListener = new DeleteListener();		
		private static MenuListener listListener = new ListListener();
		private static MenuListener selectListener = new SelectListener();

		public static void Main()
		{
			Menu m = new Menu();
			m.add("1 - Insert a new endpoint", insertListener);
			m.add("2 - Edit an existing endpoint", editListener);
			m.add("3 - Delete an existing endpoint", deleteListener);
			m.add("4 - List all endpoints", listListener);
			m.add("5 - Find a endpoint by Serial Number", selectListener);
			m.add("6 - Exit", defaultListener, true);
			m.show();
		}
	}
}
