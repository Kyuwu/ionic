using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public class InsuranceService : IInsuranceService
    {
        private O2GOContext _context;

        public InsuranceService(O2GOContext context)
        {
            _context = context;
        }

        public List<Insurance> GetInsurances()
        {
            return _context.Insurances.ToList();
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            var currentInsurances = GetInsurances();

            if (currentInsurances != null && !currentInsurances.Contains(insurance))
            {
                _context.Insurances.Add(insurance);
                _context.SaveChanges();

                return insurance;
            }

            return null;
        }

        public Insurance UpdateInsurance(Insurance insurance)
        {
            var insuranceToUpdate = _context.Insurances.FirstOrDefault(i => i.Id == insurance.Id);
            if (insuranceToUpdate != null)
            {
                _context.Insurances.FirstOrDefault(i => i.Id == insurance.Id).Name = insurance.Name;
                _context.Insurances.FirstOrDefault(i => i.Id == insurance.Id).Description = insurance.Description;
                _context.Insurances.FirstOrDefault(i => i.Id == insurance.Id).Price = insurance.Price;
                _context.SaveChanges();
                return insurance;
            }

            return null;
        }

        public Insurance RemoveInsurance(Insurance insurance)
        {
            var insuranceToRemove = _context.Insurances.FirstOrDefault(i => i.Id == insurance.Id);
            if (insuranceToRemove != null)
            {
                _context.Insurances.Remove(insurance);
                _context.SaveChanges();
                return insurance;
            }

            return null;
        }
    }
}
