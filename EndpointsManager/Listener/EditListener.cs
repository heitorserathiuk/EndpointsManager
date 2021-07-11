using EndpointsManager.Interface;
using EndpointsManager.DTO;
using EndpointsManager.Controller;
using System;

namespace EndpointsManager.Listener
{
    public class EditListener : MenuListener
    {
        private readonly EndpointController _endpointController = new EndpointController();

        public void selectedMenuOption(int option)
        {
            Console.WriteLine("You selected option  " + option);
            Console.WriteLine("Enter the Endpoint Serial Number that you want to edit:");
            string serialNumber = Console.ReadLine();
            EndpointDTO endpointDTO = new EndpointDTO();
            endpointDTO = _endpointController.Select(serialNumber);

            Console.WriteLine("Enter the value of the Switch State:");
            int switchState = Convert.ToInt32(Console.ReadLine());


            bool edit = _endpointController.Edit(endpointDTO.endpointSerialNumber, switchState);

            if (edit)
                Console.WriteLine("Endpoint {0} successfully edited!", serialNumber);

            Console.WriteLine("\n");            
        }
    }
}
