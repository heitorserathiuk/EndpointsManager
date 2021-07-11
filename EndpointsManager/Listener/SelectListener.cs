using EndpointsManager.Interface;
using EndpointsManager.DTO;
using EndpointsManager.Controller;
using System;

namespace EndpointsManager.Listener
{
    public class SelectListener : MenuListener
    {
        private readonly EndpointController _endpointController = new EndpointController();

        public void selectedMenuOption(int option)
        {            
            Console.WriteLine("You selected option  " + option);
            Console.WriteLine("Enter the Endpoint Serial Number that you want to select:");
            string serialNumber = Console.ReadLine();
            EndpointDTO endpointDTO = new EndpointDTO();
            endpointDTO = _endpointController.Select(serialNumber);
            Console.WriteLine("Serial Number : {0}", endpointDTO.endpointSerialNumber);
            Console.WriteLine("Meter Model Id : {0}", endpointDTO.meterModelId);
            Console.WriteLine("Meter Number : {0}", endpointDTO.meterNumber);
            Console.WriteLine("Meter Firmaware Version : {0}", endpointDTO.meterFirmwareVersion);
            Console.WriteLine("Switch State : {0}", endpointDTO.switchState);            
            Console.WriteLine("\n");
        }
    }
}
