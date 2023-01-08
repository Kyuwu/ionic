using O2GOBackEnd.Controllers;
using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public class ScooterService : IScooterService
    {
        private O2GOContext _context;

        public ScooterService(O2GOContext context)
        {
            _context = context;
        }

        public List<Scooter> GetScooters()
        {
            return _context.Scooters.ToList();
        }

        public Scooter CreateScooter(Scooter scooter)
        {
            var currentScooters = GetScooters();

            if (currentScooters != null && !currentScooters.Contains(scooter))
            {
                _context.Scooters.Add(scooter);
                _context.SaveChanges();

                return scooter;
            }

            return null;
        }

        public Scooter UpdateScooter(Scooter scooter)
        {
            var scooterToUpdate = _context.Scooters.FirstOrDefault(s => scooter.Id == scooter.Id);

            if (scooterToUpdate != null)
            {
                _context.Scooters.FirstOrDefault(s => scooter.Id == scooter.Id).MaxKmh = scooter.MaxKmh;
                _context.Scooters.FirstOrDefault(s => scooter.Id == scooter.Id).Brand = scooter.Brand;
                _context.Scooters.FirstOrDefault(s => scooter.Id == scooter.Id).Year = scooter.Year;
                _context.Scooters.FirstOrDefault(s => scooter.Id == scooter.Id).Description = scooter.Description;
                _context.Scooters.FirstOrDefault(s => scooter.Id == scooter.Id).Price = scooter.Price;
                _context.SaveChanges();

                return scooter;
            }

            return null;
        }

        public Scooter RemoveScooter(Scooter scooter)
        {
            var scooterToRemove = _context.Scooters.FirstOrDefault(s => s.Id == scooter.Id);

            if (scooterToRemove != null)
            {
                _context.Scooters.Remove(scooterToRemove);
                _context.SaveChanges();

                return scooter;
            }

            return null;
        }

        public Scooter AddService(Scooter scooter, Service service)
        {
            var scooterToUpdate = _context.Scooters.FirstOrDefault(s => s.Id == scooter.Id);

            if (scooter != null)
            {
                _context.Scooters.Find(scooterToUpdate).Services.Add(service);
                _context.SaveChanges();

                return _context.Scooters.Find(scooterToUpdate);
            }

            return null;
        }

        public Scooter RemoveService(Scooter scooter, Service service)
        {
            var scooterToUpdate = _context.Scooters.FirstOrDefault(s => s.Id == scooter.Id);

            if (scooter != null)
            {
                _context.Scooters.Find(scooterToUpdate).Services.Remove(service);
                _context.SaveChanges();

                return _context.Scooters.Find(scooterToUpdate);
            }

            return null;
        }

        public Scooter AddContract(Scooter scooter, Contract contract)
        {
            var scooterToUpdate = _context.Scooters.FirstOrDefault(s => s.Id == scooter.Id);

            if (scooter != null)
            {
                _context.Scooters.Find(scooterToUpdate).Contracts.Add(contract);
                _context.SaveChanges();

                return _context.Scooters.Find(scooterToUpdate);
            }

            return null;
        }

        public Scooter RemoveContract(Scooter scooter, Contract contract)
        {
            var scooterToUpdate = _context.Scooters.FirstOrDefault(s => s.Id == scooter.Id);

            if (scooter != null)
            {
                _context.Scooters.Find(scooterToUpdate).Contracts.Remove(contract);
                _context.SaveChanges();

                return _context.Scooters.Find(scooterToUpdate);
            }

            return null;
        }

        public bool CheckAvailability(Scooter scooter, DateTime from, DateTime to)
        {
            var scooterToCheck = _context.Scooters.FirstOrDefault(s => s.Id == scooter.Id);

            if (scooterToCheck != null)
            {
                var contracts = _context.Scooters
                    .FirstOrDefault(s => s.Id == scooter.Id).Contracts
                    .Where(c => from < c.EndDate && c.StartDate < to)
                    .ToList();

                if (contracts.Any())
                {
                    return false;
                }
            }

            return true;
        }

        public List<Scooter> GetScootersByAvailability(DateTime from, DateTime to)
        {
            var allScooters = _context.Scooters.ToList();
            var availableScooters = new List<Scooter>();

            foreach (var scooter in allScooters)
            {
                if (CheckAvailability(scooter, from, to))
                {
                    availableScooters.Add(scooter);
                }
            }

            return availableScooters;
        }
    }
}
