using EndpointsManager.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace EndpointsManager.Models
{
    public class Endpoint
    {
        public string endpointSerialNumber { get; set; }

        [Range(16, 19, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int meterModelId { get; set; }

        public int meterNumber { get; set; }

        public string meterFirmwareVersion { get; set; }

        [Range(0, 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int switchState { get; set; }

        public EndpointDTO ToDTO()
        {
            if (this == null) return null;

            return new EndpointDTO
            {
                endpointSerialNumber = this.endpointSerialNumber,
                meterModelId = (this.meterModelId == 16 ? "NSX1P2W" : (this.meterModelId == 17 ? "NSX1P3W" : (this.meterModelId == 18 ? "NSX2P3W" : (this.meterModelId == 19 ? "NSX3P4W" : "Invalid " + this.meterModelId)))),
                meterNumber = this.meterNumber,
                meterFirmwareVersion = this.meterFirmwareVersion,
                switchState = (this.switchState == 0 ? "Disconnected" : (this.switchState == 1 ? "Connected" : (this.switchState == 2 ? "Armed" : "Invalid " + this.switchState)))
            };
        }
    }
}
