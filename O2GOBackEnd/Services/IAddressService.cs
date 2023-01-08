using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public interface IAddressService
    {
        public Address GetAddress(int id);

        public Address UpdateAddress(Address address);
    }
}
