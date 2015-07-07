using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using brodersService.Controllers;

namespace Broders.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class PropertyControllerTests
        {
            public PropertyInfoController controller { get; set; }

            [TestInitialize]
            public void Setup()
            {
                controller = new PropertyInfoController();
                controller.Request = new System.Net.Http.HttpRequestMessage();
                controller.Configuration = new System.Web.Http.HttpConfiguration();
            }

            [TestMethod]
            public void TestGetPropertyInfo_Success()
            {
                var response = controller.GetPropertyInfo(1);

                Assert.IsNotNull(response);
            }
        }
    }
}
