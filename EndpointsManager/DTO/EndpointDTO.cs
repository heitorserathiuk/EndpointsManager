using EndpointsManager.Models;
using System.ComponentModel.DataAnnotations;

namespace EndpointsManager.DTO
{
    public class EndpointDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string endpointSerialNumber;

        [Required(AllowEmptyStrings = false)]
        public string meterModelId;

        [Required(AllowEmptyStrings = false)]
        public int meterNumber;

        [Required(AllowEmptyStrings = false)]
        public string meterFirmwareVersion;

        [Required(AllowEmptyStrings = false)]
        public string switchState;

        public static explicit operator EndpointDTO(Endpoint endpoint)
        {
            if (endpoint == null) return null;

            return new EndpointDTO
            {
                endpointSerialNumber = endpoint.endpointSerialNumber,
                meterModelId = (endpoint.meterModelId == 16 ? "NSX1P2W" : (endpoint.meterModelId == 17 ? "NSX1P3W" : (endpoint.meterModelId == 18 ? "NSX2P3W" : (endpoint.meterModelId == 19 ? "NSX3P4W" : "Invalid " + endpoint.meterModelId)))),
                meterNumber = endpoint.meterNumber,
                meterFirmwareVersion = endpoint.meterFirmwareVersion,
                switchState = (endpoint.switchState == 0 ? "Disconnected" : (endpoint.switchState == 1 ? "Connected" : (endpoint.switchState == 2 ? "Armed" : "Invalid " + endpoint.switchState)))
            };
        }
    }
}
