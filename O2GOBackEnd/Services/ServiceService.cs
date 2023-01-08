using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public class ServiceService : IServiceService
    {
        private O2GOContext _context;

        public ServiceService(O2GOContext context)
        {
            _context = context;
        }

        public List<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        public Service CreateService(Service service)
        {
            var currentServices = GetServices();

            if(currentServices != null && !currentServices.Contains(service))
            {
                _context.Services.Add(service);
                _context.SaveChanges();

                return service;
            }

            return null;
        }

        public Service UpdateService(Service service)
        {
            var serviceToUpdate = _context.Services.FirstOrDefault(s => s.Id == service.Id);

            if (serviceToUpdate != null)
            {
                _context.Services.FirstOrDefault(s => s.Id == service.Id).Description = service.Description;
                _context.Services.FirstOrDefault(s => s.Id == service.Id).Servicepoint = service.Servicepoint;
                _context.Services.FirstOrDefault(s => s.Id == service.Id).Scooter = service.Scooter;
                _context.Services.FirstOrDefault(s => s.Id == service.Id).Date = service.Date;
                _context.SaveChanges();

                return service;
            }

            return null;
        }

        public Service RemoveService(Service service)
        {
            var serviceToRemove = _context.Services.FirstOrDefault(s => s.Id == service.Id);

            if (serviceToRemove != null)
            {
                _context.Services.Remove(serviceToRemove);
                _context.SaveChanges();

                return service;
            }

            return null;
        }
    }
}
