using EndpointsManager;
using EndpointsManager.Controller;
using EndpointsManager.DTO;
using EndpointsManager.ExceptionErrors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.IO;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEndpointCreation()
        {
            bool creation = true;
            EndpointController endpointController = new EndpointController();

            EndpointDTO endpointDTO = new EndpointDTO();
            endpointDTO.endpointSerialNumber = "Serial Number 1";
            endpointDTO.meterModelId = "NSX1P2W";
            endpointDTO.meterFirmwareVersion = "v1";
            endpointDTO.meterNumber = 100;
            endpointDTO.switchState = "0";

            try
            {
                creation = endpointController.Create(endpointDTO);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            if (!creation)
                Assert.Fail();
        }

        [TestMethod]
        public void TestCreationTwoEqualEndpoint()
        {
            bool creation1 = true, creation2 = true;
            EndpointController endpointController = new EndpointController();

            EndpointDTO endpointDTO1 = new EndpointDTO();
            endpointDTO1.endpointSerialNumber = "Serial Number 2";
            endpointDTO1.meterModelId = "NSX1P3W";
            endpointDTO1.meterFirmwareVersion = "v2";
            endpointDTO1.meterNumber = 200;
            endpointDTO1.switchState = "0";

            EndpointDTO endpointDTO2 = new EndpointDTO();
            endpointDTO2.endpointSerialNumber = "Serial Number 2";
            endpointDTO2.meterModelId = "NSX1P3W";
            endpointDTO2.meterFirmwareVersion = "v2";
            endpointDTO2.meterNumber = 200;
            endpointDTO2.switchState = "0";

            try
            {
                creation1 = endpointController.Create(endpointDTO1);
                creation2 = endpointController.Create(endpointDTO2);
            }
            catch (ErrorException e)
            {
                Assert.Fail();
            }

            if(creation1 && creation2)
                Assert.Fail();
        }

        [TestMethod]
        public void TestCreationTwoDifferentEndpoint()
        {
            bool creation1 = true, creation2 = true;
            EndpointController endpointController = new EndpointController();

            EndpointDTO endpointDTO1 = new EndpointDTO();
            endpointDTO1.endpointSerialNumber = "Serial Number 3";
            endpointDTO1.meterModelId = "NSX2P3W";
            endpointDTO1.meterFirmwareVersion = "v3";
            endpointDTO1.meterNumber = 300;
            endpointDTO1.switchState = "1";

            EndpointDTO endpointDTO2 = new EndpointDTO();
            endpointDTO2.endpointSerialNumber = "Serial Number 4";
            endpointDTO2.meterModelId = "NSX3P4W";
            endpointDTO2.meterFirmwareVersion = "v4";
            endpointDTO2.meterNumber = 400;
            endpointDTO2.switchState = "2";

            try
            {
                creation1 = endpointController.Create(endpointDTO1);
                creation2 = endpointController.Create(endpointDTO2);
            }
            catch (ErrorException e)
            {
                Assert.Fail();
            }

            if (!(creation1 && creation2))
                Assert.Fail();
        }

        [TestMethod]
        public void EditingTest()
        {
            bool edit = true;
            bool creation = true;
            EndpointController endpointController = new EndpointController();

            EndpointDTO endpointDTO = new EndpointDTO();
            endpointDTO.endpointSerialNumber = "Serial Number 5";
            endpointDTO.meterModelId = "NSX3P4W";
            endpointDTO.meterFirmwareVersion = "v5";
            endpointDTO.meterNumber = 500;
            endpointDTO.switchState = "2";

            try
            {
                creation = endpointController.Create(endpointDTO);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            if (!creation)
                Assert.Fail();

            string id = "Serial Number 5";
            int switchState = 0;

            try
            {
                edit = endpointController.Edit(id, switchState);
            }
            catch (ErrorException e)
            {
                Assert.Fail();
            }

            if (!edit)
                Assert.Fail();
        }
    }
}
