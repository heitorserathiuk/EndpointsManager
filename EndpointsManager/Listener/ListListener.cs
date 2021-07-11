using EndpointsManager.Interface;
using EndpointsManager.DTO;
using EndpointsManager.Controller;
using System;
using System.Collections.Generic;

namespace EndpointsManager.Listener
{
    public class ListListener : MenuListener
    {
        private readonly EndpointController _endpointController = new EndpointController();

        public void selectedMenuOption(int option)
        {
            List<EndpointDTO> endpointsDTOList = new List<EndpointDTO>();
            endpointsDTOList = _endpointController.List();
            Console.WriteLine("You selected option  " + option);


            if (endpointsDTOList.Count > 0)
            {
                Console.WriteLine("Check all available endpoints below:");

                foreach (EndpointDTO endpointDTO in endpointsDTOList)
                {
                    Console.WriteLine("Serial Number : {0}", endpointDTO.endpointSerialNumber);
                    Console.WriteLine("Meter Model Id : {0}", endpointDTO.meterModelId);
                    Console.WriteLine("Meter Number : {0}", endpointDTO.meterNumber);
                    Console.WriteLine("Meter Firmaware Version : {0}", endpointDTO.meterFirmwareVersion);
                    Console.WriteLine("Switch State : {0}", endpointDTO.switchState);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("No endpoints available.");                
            }

            Console.WriteLine("\n");
        }
    }
}
