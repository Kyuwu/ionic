using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public interface IServicepointService
    {
        List<Servicepoint> GetServicepoints();

        Servicepoint CreateServicepoint(Servicepoint servicepoint);

        Servicepoint UpdateServicepoint(Servicepoint servicepoint);

        Servicepoint RemoveServicepoint(Servicepoint servicepoint);
    }
}
