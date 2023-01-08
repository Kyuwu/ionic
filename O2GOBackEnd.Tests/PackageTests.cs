using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Controllers;
using O2GOBackEnd.Models;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Tests
{
    public class PackageTests
    {
        O2GOContext context;
        PackageController controller;

        public void Initialize()
        {
            context = new O2GOContext();
            var packageService = new PackageService(context);
            controller = new PackageController(packageService);
        }

        [Fact]
        public void CreatePackageTest()
        {
            Initialize();

            var packageToCreate = new Package()
            {
                Name = "Basis pakket",
                Description = "Incl. WA & WA Casco",
                Price = 25.50m
            };

            var objectResult = controller.CreatePackage(packageToCreate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void UpdatePackageTest()
        {
            Initialize();

            var initializePackage = new Package()
            {
                Name = "Basis pakket",
                Description = "Incl. WA & WA Casco",
                Price = 25.50m
            };

            controller.CreatePackage(initializePackage);

            var firstObjectResult = controller.GetPackages() as OkObjectResult;
            var firstFoundPackages = firstObjectResult.Value as List<Package>;

            var packageToUpdate = firstFoundPackages.FirstOrDefault(s => s.Name.Equals(initializePackage.Name));
            packageToUpdate.Description = "Inclusief WA & WA Casco";

            var objectResult = controller.UpdatePackage(packageToUpdate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void RemovePackageTest()
        {
            Initialize();

            var initializePackage = new Package()
            {
                Name = "Basis pakket",
                Description = "Incl. WA & WA Casco",
                Price = 25.50m
            };

            controller.CreatePackage(initializePackage);

            var objectResult = controller.RemovePackage(initializePackage);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }
    }
}