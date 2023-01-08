using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public interface IScooterService
    {
        List<Scooter> GetScooters();

        Scooter CreateScooter(Scooter scooter);

        Scooter UpdateScooter(Scooter scooter);

        Scooter RemoveScooter(Scooter scooter);

        Scooter AddService(Scooter scooter, Service service);

        Scooter RemoveService(Scooter scooter, Service service);

        Scooter AddContract(Scooter scooter, Contract contract);

        Scooter RemoveContract(Scooter scooter, Contract contract);
        
        bool CheckAvailability(Scooter scooter, DateTime from, DateTime to);

        List<Scooter> GetScootersByAvailability(DateTime from, DateTime to);
    }
}
