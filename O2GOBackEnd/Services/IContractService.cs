using Microsoft.AspNetCore.Identity;
using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public interface IContractService
    {
        List<Contract> GetContracts();
        List<Contract> GetContractsForUser(string userId);

        Contract CreateContract(Contract contract);

        Contract UpdateContract(Contract contract);

        Contract RemoveContract(Contract contract);
    }
}
