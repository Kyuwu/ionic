using O2GOBackEnd.Models;

namespace O2GOBackEnd.Services
{
    public class AddressService : IAddressService
    {
        private O2GOContext _context;

        public AddressService(O2GOContext context)
        {
            _context = context;
        }

        public Address GetAddress(int id)
        {
            return _context.Addresses.FirstOrDefault(a => a.Id == id);
        }

        public Address UpdateAddress(Address address)
        {
            var addressToUpdate = _context.Addresses.FirstOrDefault(a => a.Id == address.Id);

            if(addressToUpdate != null)
            {
                _context.Addresses.FirstOrDefault(a => a.Id == address.Id).Street = address.Street;
                _context.Addresses.FirstOrDefault(a => a.Id == address.Id).Number = address.Number;
                _context.Addresses.FirstOrDefault(a => a.Id == address.Id).City = address.City;
                _context.Addresses.FirstOrDefault(a => a.Id == address.Id).PostalCode = address.PostalCode;

                _context.SaveChanges();
                return address;
            }

            return null;
        }
    }
}
