using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Controllers;
using O2GOBackEnd.Models;
using O2GOBackEnd.Models.Resources;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Tests
{
    public class ServicepointTests
    {
        O2GOContext context;
        ServicepointController controller;

        public void Initialize()
        {
            context = new O2GOContext();
            var servicepointService = new ServicepointService(context);
            controller = new ServicepointController(servicepointService);
        }

        [Fact]
        public void CreateServicepointTest()
        {
            Initialize();

            var address = new Address()
            {
                Street = "Servicelaan",
                Number = 21,
                PostalCode = "2543SP",
                City = "Servicestad"
            };

            var servicepointToCreate = new Servicepoint()
            {
                Name = "Servicestad servicepunt",
                Address = address,
                AddressId = address.Id
            };

            var objectResult = controller.CreateServicepoint(servicepointToCreate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void UpdateServicepointTest()
        {
            Initialize();

            var address = new Address()
            {
                Street = "Servicelaan",
                Number = 21,
                PostalCode = "2543SP",
                City = "Servicestad"
            };

            var initializeServicepoint = new Servicepoint()
            {
                Name = "Servicestad servicepunt",
                Address = address,
                AddressId = address.Id
            };

            controller.CreateServicepoint(initializeServicepoint);

            var firstObjectResult = controller.GetServicepoints() as OkObjectResult;
            var firstFoundServicepoints = firstObjectResult.Value as List<Servicepoint>;

            var servicepointToUpdate = firstFoundServicepoints.FirstOrDefault(s => s.Name.Equals(initializeServicepoint.Name));
            servicepointToUpdate.Name = "Servicepunt van Servicestad";

            var objectResult = controller.UpdateServicepoint(servicepointToUpdate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void RemoveServicepointTest()
        {
            Initialize();

            var address = new Address()
            {
                Street = "Servicelaan",
                Number = 21,
                PostalCode = "2543SP",
                City = "Servicestad"
            };

            var initializeServicepoint = new Servicepoint()
            {
                Name = "Servicestad servicepunt",
                Address = address,
                AddressId = address.Id
            };

            controller.CreateServicepoint(initializeServicepoint);

            var objectResult = controller.RemoveServicepoint(initializeServicepoint);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }
    }
}