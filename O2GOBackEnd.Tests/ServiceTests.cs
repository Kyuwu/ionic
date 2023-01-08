using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Controllers;
using O2GOBackEnd.Models;
using O2GOBackEnd.Models.Resources;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Tests
{
    public class ServiceTests
    {
        O2GOContext context;
        ServiceController controller;

        public void Initialize()
        {
            context = new O2GOContext();
            var serviceService = new ServiceService(context);
            controller = new ServiceController(serviceService);
        }

        [Fact]
        public void CreateServiceTest()
        {
            Initialize();

            var scooter = new Scooter()
            {
                Brand = "AGM",
                LicensePlate = "FDB85X",
                MaxKmh = 45,
                Year = 2019,
                Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk.",
                Price = 55.30m
            };

            var scooterService = new ScooterService(context);
            var scooterController = new ScooterController(scooterService);
            scooterController.CreateScooter(scooter);

            var address = new Address()
            {
                Street = "Servicelaan",
                Number = 21,
                PostalCode = "2543SP",
                City = "Servicestad"
            };

            var servicepoint = new Servicepoint()
            {
                Name = "Servicestad servicepunt",
                Address = address,
                AddressId = address.Id
            };

            var servicepointService = new ServicepointService(context);
            var servicepointController = new ServicepointController(servicepointService);
            servicepointController.CreateServicepoint(servicepoint);

            var serviceToCreate = new Service()
            {
                Description = "Aanpak",
                Date = DateTime.Now.AddDays(5),
                Servicepoint = servicepoint,
                ServicepointId = servicepoint.Id,
                Scooter = scooter,
                ScooterId = scooter.Id
            };

            var objectResult = controller.CreateService(serviceToCreate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void UpdateServiceTest()
        {
            Initialize();

            var scooter = new Scooter()
            {
                Brand = "AGM",
                LicensePlate = "FDB85X",
                MaxKmh = 45,
                Year = 2019,
                Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk.",
                Price = 55.30m
            };

            var scooterService = new ScooterService(context);
            var scooterController = new ScooterController(scooterService);
            scooterController.CreateScooter(scooter);

            var address = new Address()
            {
                Street = "Servicelaan",
                Number = 21,
                PostalCode = "2543SP",
                City = "Servicestad"
            };

            var servicepoint = new Servicepoint()
            {
                Name = "Servicestad servicepunt",
                Address = address,
                AddressId = address.Id
            };

            var servicepointService = new ServicepointService(context);
            var servicepointController = new ServicepointController(servicepointService);
            servicepointController.CreateServicepoint(servicepoint);

            var initializeService = new Service()
            {
                Description = "Aanpak",
                Date = DateTime.Now.AddDays(5),
                Servicepoint = servicepoint,
                ServicepointId = servicepoint.Id,
                Scooter = scooter,
                ScooterId = scooter.Id
            };

            controller.CreateService(initializeService);

            var firstObjectResult = controller.GetServices() as OkObjectResult;
            var firstFoundServices = firstObjectResult.Value as List<Service>;

            var serviceToUpdate = firstFoundServices.FirstOrDefault(s => s.Description.Equals(initializeService.Description) && s.Date.Equals(initializeService.Date));
            serviceToUpdate.Description = "Aanpak aan motor, laad traag op.";

            var objectResult = controller.UpdateService(serviceToUpdate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void RemoveServiceTest()
        {
            Initialize();

            var scooter = new Scooter()
            {
                Brand = "AGM",
                LicensePlate = "FDB85X",
                MaxKmh = 45,
                Year = 2019,
                Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk.",
                Price = 55.30m
            };

            var scooterService = new ScooterService(context);
            var scooterController = new ScooterController(scooterService);
            scooterController.CreateScooter(scooter);

            var address = new Address()
            {
                Street = "Servicelaan",
                Number = 21,
                PostalCode = "2543SP",
                City = "Servicestad"
            };

            var servicepoint = new Servicepoint()
            {
                Name = "Servicestad servicepunt",
                Address = address,
                AddressId = address.Id
            };

            var servicepointService = new ServicepointService(context);
            var servicepointController = new ServicepointController(servicepointService);
            servicepointController.CreateServicepoint(servicepoint);

            var initializeService = new Service()
            {
                Description = "Aanpak",
                Date = DateTime.Now.AddDays(5),
                Servicepoint = servicepoint,
                ServicepointId = servicepoint.Id,
                Scooter = scooter,
                ScooterId = scooter.Id
            };

            controller.CreateService(initializeService);

            var objectResult = controller.RemoveService(initializeService);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }
    }
}