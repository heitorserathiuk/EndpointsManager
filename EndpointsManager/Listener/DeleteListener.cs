using EndpointsManager.Interface;
using EndpointsManager.DTO;
using EndpointsManager.Controller;
using System;

namespace EndpointsManager.Listener
{
    public class DeleteListener : MenuListener
    {
        private readonly EndpointController _endpointController = new EndpointController();

        public void selectedMenuOption(int option)
        {
            Console.WriteLine("You selected option  " + option);
            Console.WriteLine("Enter the Endpoint Serial Number that you want to delete:");
            string serialNumber = Console.ReadLine();
            EndpointDTO endpoint = new EndpointDTO();
            endpoint = _endpointController.Select(serialNumber);
            string deleteOption;
            do
            {
                Console.WriteLine("Do you want to proceed with the deletion ? (y/n)");
                deleteOption = Console.ReadLine();

                if (deleteOption.Equals("y"))
                {
                    bool delete = _endpointController.Delete(endpoint);

                    if (delete)
                        Console.WriteLine("Endpoint {0} successfully deleted!", serialNumber);

                    Console.WriteLine("\n");
                }
                else if (!deleteOption.Equals("n"))
                {
                    Console.WriteLine("Invalid Option. Type s to confirm the deletion, and type n to cancel the deletion.");
                    Console.WriteLine("\n");
                }
            } while (!(deleteOption.Equals("y") || deleteOption.Equals("n")));
        }
    }
}
