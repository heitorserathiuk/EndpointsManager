using EndpointsManager.DTO;
using EndpointsManager.ExceptionErrors;
using EndpointsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EndpointsManager.Controller
{
    public class EndpointController
    {
        private readonly Context _context;

        public EndpointController()
        {
            _context = Program.context;
        }

        public bool Create(EndpointDTO endpointDTO)
        {
            try
            {
                bool exist = EndpointExists(endpointDTO.endpointSerialNumber);
                if(exist)
                    throw new ErrorException("Endpoint Serial Number already exists.");


                MeterModelText meterModelText = new MeterModelText();
                int meterModelId = 0;
                int switchState = -1;

                if (endpointDTO.meterModelId.Equals("NSX1P2W"))
                    meterModelId = meterModelText.NSX1P2W;
                else if (endpointDTO.meterModelId.Equals("NSX1P3W"))
                    meterModelId = meterModelText.NSX1P3W;
                else if (endpointDTO.meterModelId.Equals("NSX2P3W"))
                    meterModelId = meterModelText.NSX2P3W;
                else if (endpointDTO.meterModelId.Equals("NSX3P4W"))
                    meterModelId = meterModelText.NSX3P4W;
                else if (endpointDTO.meterModelId.Equals("16"))
                    meterModelId = meterModelText.NSX1P2W;
                else if (endpointDTO.meterModelId.Equals("17"))
                    meterModelId = meterModelText.NSX1P3W;
                else if (endpointDTO.meterModelId.Equals("18"))
                    meterModelId = meterModelText.NSX2P3W;
                else if (endpointDTO.meterModelId.Equals("19"))
                    meterModelId = meterModelText.NSX3P4W;
                else
                    throw new ErrorException("Invalid Meter Model Id.");

                SwitchStateText switchStateText = new SwitchStateText();
                if (endpointDTO.switchState.Equals("Disconnected"))
                    switchState = switchStateText.Disconnected;
                else if (endpointDTO.switchState.Equals("Connected"))
                    switchState = switchStateText.Connected;
                else if (endpointDTO.switchState.Equals("Armed"))
                    switchState = switchStateText.Armed;
                else if (endpointDTO.switchState.Equals("0"))
                    switchState = switchStateText.Disconnected;
                else if (endpointDTO.switchState.Equals("1"))
                    switchState = switchStateText.Connected;
                else if (endpointDTO.switchState.Equals("2"))
                    switchState = switchStateText.Armed;
                else
                    throw new ErrorException("Invalid Switch State.");

                Endpoint endpoint = new Endpoint();
                endpoint.endpointSerialNumber = endpointDTO.endpointSerialNumber;
                endpoint.meterFirmwareVersion = endpointDTO.meterFirmwareVersion;
                endpoint.meterModelId = meterModelId;
                endpoint.meterNumber = endpointDTO.meterNumber;
                endpoint.switchState = switchState;
                _context.endpoints.Add(endpoint);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }            
        }

        public bool Edit(string id, int switchState)
        {
            try
            {
                Endpoint endpoint = _context.endpoints.Where(e => e.endpointSerialNumber == id).FirstOrDefault();
                endpoint.switchState = switchState; 
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }            
        }

        public bool Delete(EndpointDTO endpointDTO)
        {
            Endpoint endpoint =  _context.endpoints.Where(e => e.endpointSerialNumber == endpointDTO.endpointSerialNumber).FirstOrDefault();

            if (endpoint != null)
            {
                _context.endpoints.Remove(endpoint);
                return true;
            }
            else
            {
                throw new ErrorException("Serial Number Not Found.");
            }            
        }

        public List<EndpointDTO> List()
        {
            List<EndpointDTO> endpointsDTOList = new List<EndpointDTO>();
            endpointsDTOList = _context.endpoints.Select(x => x.ToDTO()).ToList();
            return endpointsDTOList;
        }

        public EndpointDTO Select(string id)
        {
            EndpointDTO endpointDTO = (EndpointDTO)_context.endpoints.Where(e => e.endpointSerialNumber == id).FirstOrDefault();
            return endpointDTO;
        }

        public bool EndpointExists(string id)
        {
            return _context.endpoints.Any(e => e.endpointSerialNumber == id);
        }        
    }
}
