using Microsoft.AspNetCore.Identity;
using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public class ContractService : IContractService
    {
        private O2GOContext _context;

        public ContractService(O2GOContext context)
        {
            _context = context;
        }

        public List<Contract> GetContracts()
        {
            return _context.Contracts.ToList();
        }

        public List<Contract> GetContractsForUser(string userId)
        {
            var applicationUser = _context.ApplicationUsers.FirstOrDefault(a => a.UserId == userId);
            if (applicationUser == null) return null;
            return _context.Contracts.Where(c => c.UserId == applicationUser.Id).ToList();
        }

        public Contract CreateContract(Contract contract)
        {
            var currentContracts = GetContracts();

            if (currentContracts != null && !currentContracts.Contains(contract))
            {
                _context.Contracts.Add(contract);
                _context.SaveChanges();

                return contract;
            }

            return null;
        }

        public Contract UpdateContract(Contract contract)
        {
            var contractToUpdate = _context.Contracts.FirstOrDefault(c => c.Id == contract.Id);

            if (contractToUpdate != null)
            {
                contractToUpdate.StartDate = contract.StartDate;
                contractToUpdate.EndDate = contract.EndDate;
                contractToUpdate.Package = contract.Package;
                contractToUpdate.Scooter = contract.Scooter;
                contractToUpdate.ContractInsurances = contract.ContractInsurances;
                _context.SaveChanges();

                return contract;
            }

            return null;
        }

        public Contract RemoveContract(Contract contract)
        {
            var contractToRemove = _context.Services.FirstOrDefault(c => c.Id == contract.Id);

            if (contractToRemove != null)
            {
                _context.Services.Remove(contractToRemove);
                _context.SaveChanges();

                return contract;
            }

            return null;
        }
    }
}
