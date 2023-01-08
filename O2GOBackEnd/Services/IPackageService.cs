using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public interface IPackageService
    {
        List<Package> GetPackages();

        Package CreatePackage(Package package);

        Package UpdatePackage(Package package);

        Package RemovePackage(Package package);
    }
}
