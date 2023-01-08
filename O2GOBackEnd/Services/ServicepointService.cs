using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public class ServicepointService : IServicepointService
    {
        private O2GOContext _context;

        public ServicepointService(O2GOContext context)
        {
            _context = context;
        }

        public List<Servicepoint> GetServicepoints()
        {
            return _context.Servicepoints.ToList();
        }

        public Servicepoint CreateServicepoint(Servicepoint servicepoint)
        {
            var servicepoints = GetServicepoints();

            if (servicepoints != null && !servicepoints.Contains(servicepoint))
            {
                _context.Servicepoints.Add(servicepoint);
                _context.SaveChanges();

                return servicepoint;
            }

            return null;
        }

        public Servicepoint UpdateServicepoint(Servicepoint servicepoint)
        {
            var servicepointToUpdate = _context.Servicepoints.FirstOrDefault(sp => sp.Id == servicepoint.Id);

            if (servicepointToUpdate != null)
            {
                servicepointToUpdate.Name = servicepoint.Name;
                servicepointToUpdate.Address = servicepoint.Address;
                _context.SaveChanges();

                return servicepoint;
            }

            return null;
        }

        public Servicepoint RemoveServicepoint(Servicepoint servicepoint)
        {
            var servicepointToRemove = _context.Servicepoints.FirstOrDefault(sp => sp.Id == servicepoint.Id);

            if (servicepointToRemove != null)
            {
                _context.Servicepoints.Remove(servicepointToRemove);
                _context.SaveChanges();

                return servicepoint;
            }

            return null;
        }
    }
}
