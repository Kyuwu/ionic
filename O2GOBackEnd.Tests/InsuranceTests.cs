using Microsoft.AspNetCore.Mvc;
using O2GOBackEnd.Controllers;
using O2GOBackEnd.Models;
using O2GOBackEnd.Models.Resources;
using O2GOBackEnd.Services;

namespace O2GOBackEnd.Tests
{
    public class InsuranceTests
    {
        O2GOContext context;
        InsuranceController controller;

        public void Initialize()
        {
            context = new O2GOContext();
            var insuranceService = new InsuranceService(context);
            controller = new InsuranceController(insuranceService);
        }

        [Fact]
        public void CreateInsuranceTest()
        {
            Initialize();

            var insuranceToCreate = new Insurance()
            {
                Name = "WA Verzekering",
                Description = "Verzekering om de schade te vergoeden aan de tegenpartij.",
                Price = 12.50m
            };

            var objectResult = controller.CreateInsurance(insuranceToCreate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void UpdateInsuranceTest()
        {
            Initialize();

            var initializeInsurance = new Insurance()
            {
                Name = "WA Verzekering",
                Description = "Verzekering om de schade te vergoeden aan de tegenpartij.",
                Price = 12.50m
            };

            controller.CreateInsurance(initializeInsurance);

            var firstObjectResult = controller.GetInsurances() as OkObjectResult;
            var firstFoundInsurances = firstObjectResult.Value as List<Insurance>;

            var insuranceToUpdate = firstFoundInsurances.FirstOrDefault(s => s.Name.Equals(initializeInsurance.Name));
            insuranceToUpdate.Description = "Verzekering om de schade te vergoeden aan de tegenpartij. Daarbij wordt eigen schade NIET vergoed!";

            var objectResult = controller.UpdateInsurance(insuranceToUpdate);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }

        [Fact]
        public void RemoveInsuranceTest()
        {
            Initialize();

            var initializeInsurance = new Insurance()
            {
                Name = "WA Verzekering",
                Description = "Verzekering om de schade te vergoeden aan de tegenpartij.",
                Price = 12.50m
            };

            controller.CreateInsurance(initializeInsurance);

            var objectResult = controller.RemoveInsurance(initializeInsurance);

            Assert.IsNotType<BadRequestObjectResult>(objectResult);
            Assert.IsType<OkObjectResult>(objectResult);
        }
    }
}