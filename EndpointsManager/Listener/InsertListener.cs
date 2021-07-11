using EndpointsManager.Interface;
using EndpointsManager.DTO;
using EndpointsManager.Controller;
using System;

namespace EndpointsManager.Listener
{
    public class InsertListener : MenuListener
    {
        private readonly EndpointController _endpointController = new EndpointController();
        public void selectedMenuOption(int option)
        {
            Console.WriteLine("You selected option  " + option);
            string serialNumber = "";
            bool exist;

            do
            {
                Console.WriteLine("Enter a new Serial Number value:");
                serialNumber = Console.ReadLine();
                exist = _endpointController.EndpointExists(serialNumber);

                if(exist == true)
                {
                    Console.WriteLine("There is already a Serial Number with the same value.");
                    Console.WriteLine("\n");
                }

            } while (exist == true);

            Console.WriteLine("Enter a Meter Model Id value:");
            string meterModelId = Console.ReadLine();

            Console.WriteLine("Enter a Meter Number value:");
            int meterNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a Meter Firmware Version value:");
            string meterFirmwareVersion = Console.ReadLine();

            Console.WriteLine("Enter a Switch State value:");
            string switchState = Console.ReadLine();             

            EndpointDTO endpoint = new EndpointDTO();
            endpoint.endpointSerialNumber = serialNumber;
            endpoint.meterModelId = meterModelId;
            endpoint.meterNumber = meterNumber;
            endpoint.meterFirmwareVersion = meterFirmwareVersion;
            endpoint.switchState = switchState;

            bool create = _endpointController.Create(endpoint);

            if (create)
                Console.WriteLine("Endpoint {0} successfully created!", serialNumber);

            Console.WriteLine("\n");
        }
    }
}
