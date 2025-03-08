using NOGA.Server.Models;
using NOGA.Server.Models.CustomerDTO;

namespace NOGA.Server.Services
{
    public interface ICustomerServices
    {
        Task<List<Customers>> GetCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task<Customers> AddCustomer(Customers customer);
        Task<bool> UpdateCustomerAsync(int id , Customers customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<Customers?> AddCustomerAsync(Customers newCustomer);


    }
}
