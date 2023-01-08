using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public interface IServiceService
    {
        List<Service> GetServices();

        Service CreateService(Service service);

        Service UpdateService(Service service);

        Service RemoveService(Service service);
    }
}
