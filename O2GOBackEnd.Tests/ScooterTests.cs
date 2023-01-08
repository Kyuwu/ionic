using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Controllers;
using O2GOBackEnd.Models;
using O2GOBackEnd.Models.Resources;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Tests
{
    public class ScooterTests
    {
        O2GOContext context;
        ScooterController controller;

        public void Initialize()
        {
            context = new O2GOContext();
            var scooterService = new ScooterService(context);
            controller = new ScooterController(scooterService);
        }

        [Fact]
        public void CreateScooterTest()
        {
            Initialize();

            var scooterToCreate = new Scooter()
            {
                Brand = "AGM",
                LicensePlate = "FDB85X",
                MaxKmh = 45,
                Year = 2019,
                Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk.",
                Price = 55.30m
            };

            var objectResult = controller.CreateScooter(scooterToCreate) as OkObjectResult;
            var createdScooter = objectResult.Value as Scooter;

            Assert.Equal(createdScooter, scooterToCreate);
        }

        [Fact]
        public void UpdateScooterTest()
        {
            Initialize();

            var initializeScooter = new Scooter()
            {
                Brand = "AGM",
                LicensePlate = "FDB85X",
                MaxKmh = 45,
                Year = 2019,
                Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk.",
                Price = 55.30m
            };

            controller.CreateScooter(initializeScooter);

            var firstObjectResult = controller.GetScooters() as OkObjectResult;
            var firstFoundScooters = firstObjectResult.Value as List<Scooter>;
            
            var scooterToUpdate = firstFoundScooters.FirstOrDefault(s => s.LicensePlate.Equals(initializeScooter.LicensePlate));
            scooterToUpdate.Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk. Hard windscherm, zodat u nooit wind in uw gezicht krijgt.";
            
            var objectResult = controller.UpdateScooter(scooterToUpdate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void RemoveScooterTest()
        {
            Initialize();

            var scooterToCreate = new Scooter()
            {
                Brand = "AGM",
                LicensePlate = "FDB85X",
                MaxKmh = 45,
                Year = 2019,
                Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk.",
                Price = 55.30m
            };

            controller.CreateScooter(scooterToCreate);

            var objectResult = controller.RemoveScooter(scooterToCreate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void GetScooterAvailabilityTest()
        {
            Initialize();

            var scooterToCreate = new Scooter()
            {
                Brand = "AGM",
                LicensePlate = "FDB85X",
                MaxKmh = 45,
                Year = 2019,
                Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk.",
                Price = 55.30m
            };

            controller.CreateScooter(scooterToCreate);

            var objectResult = controller.GetAvailableScootersByDates(new FromToInputModel()
            {
                From = DateTime.Now,
                To = DateTime.Now.AddDays(5)
            }) as OkObjectResult;
            var foundScooters = objectResult.Value as List<Scooter>;

            Assert.Contains(scooterToCreate, foundScooters);
        }

        [Fact]
        public void CheckAvailabilityTest()
        {
            Initialize();

            var scooterToCreate = new Scooter()
            {
                Brand = "AGM",
                LicensePlate = "FDB85X",
                MaxKmh = 45,
                Year = 2019,
                Description = "Goede betrouwbare scooter, loopt strak 45. Motorisch sterk.",
                Price = 55.30m
            };

            controller.CreateScooter(scooterToCreate);

            var objectResult = controller.CheckAvailability(new ScooterFromToInputModel()
            {
                From = DateTime.Now,
                To = DateTime.Now.AddDays(5),
                Scooter = scooterToCreate
            });

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }
    }
}