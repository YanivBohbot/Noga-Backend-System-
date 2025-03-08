using Microsoft.EntityFrameworkCore;
using NOGA.Server.Data;
using NOGA.Server.Models;
using NOGA.Server.Models.CustomerDTO;

namespace NOGA.Server.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly AppDbContext _context;

        public CustomerServices(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Customers> AddCustomerAsync(Customers newCustomer)
        {
            if (newCustomer == null)
            {
                return null;
            }

                newCustomer.CreatedAt = DateTime.Now;
                newCustomer.isDeleted = false;

                foreach (var address in newCustomer.Addresses)
                {
                    address.CustomerId = newCustomer.Id;
                }

                foreach (var contact in newCustomer.Contacts)
                {
                    contact.CustomerId = newCustomer.Id;  // מנטרל את הקישור הדו-כיווני
                }

               _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();
          
            return newCustomer;

            
        }




        public async Task<List<Customers>> GetCustomersAsync()
        {
            return await _context.Customers
                .Where(c => !c.isDeleted)
                .ToListAsync();
        }


        // עדכון לקוח קיים
        public async Task<bool> UpdateCustomerAsync(int id, Customers updatedCustomer)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null || customer.isDeleted)
            {
                return false;
            }

            customer.Name = updatedCustomer.Name;
            customer.CustomerNumber = updatedCustomer.CustomerNumber;
            customer.Contacts = updatedCustomer.Contacts;
            customer.Addresses = updatedCustomer.Addresses;


            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Addresses)
                .Include(c => c.Contacts)
                .FirstOrDefaultAsync(c => c.Id == id && c.isDeleted == false);


            var customerDTO = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                CustomerNumber = customer.CustomerNumber,
                Addresses = customer.Addresses.Select(a => new AddressDTO
                {
                    Id = a.Id,
                    City = a.City,
                    Street = a.Street
                }).ToList(),
                Contacts = customer.Contacts.Select(c => new ContactDTO
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    OfficeNumber = c.OfficeNumber,
                    Email = c.Email
                }).ToList()
            };


                return customerDTO;

            }

        public async Task<Customers> AddCustomer(Customers customer)
        {
            customer.CreatedAt = System.DateTime.Now;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

      
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers
                   .Include(c => c.Addresses)
                   .Include(c => c.Contacts)
                   .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null || customer.isDeleted)
            {
                return false;
            }

            customer.isDeleted = true;
            customer.Addresses.ToList().ForEach(a => a.isDeleted = true);
            customer.Contacts.ToList().ForEach(c => c.isDeleted = true);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
