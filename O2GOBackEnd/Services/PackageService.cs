using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public class PackageService : IPackageService
    {
        private O2GOContext _context;

        public PackageService(O2GOContext context)
        {
            _context = context;
        }

        public List<Package> GetPackages()
        {
            return _context.Packages.ToList();
        }

        public Package CreatePackage(Package package)
        {
            var currentPackages = GetPackages();

            if (currentPackages != null && !currentPackages.Contains(package))
            {
                _context.Packages.Add(package);
                _context.SaveChanges();

                return package;
            }

            return null;
        }

        public Package UpdatePackage(Package package)
        {
            var packageToUpdate = _context.Packages.FirstOrDefault(p => p.Id == package.Id);

            if (packageToUpdate != null)
            {
                _context.Packages.FirstOrDefault(p => p.Id == package.Id).Name = package.Name;
                _context.Packages.FirstOrDefault(p => p.Id == package.Id).Description = package.Description;
                _context.Packages.FirstOrDefault(p => p.Id == package.Id).Price = package.Price;
                _context.SaveChanges();

                return package;
            }

            return null;
        }

        public Package RemovePackage(Package package)
        {
            var packageToRemove = _context.Packages.FirstOrDefault(p => p.Id == package.Id);

            if (packageToRemove != null)
            {
                _context.Packages.Remove(packageToRemove);
                _context.SaveChanges();

                return package;
            }

            return null;
        }
    }
}
