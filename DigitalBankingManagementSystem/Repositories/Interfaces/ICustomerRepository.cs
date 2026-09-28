using DigitalBankingManagementSystem.Models;

namespace DigitalBankingManagementSystem.Repositories.Interfaces
{
	public interface ICustomerRepository
	{
		Task<List<Customer>> GetCustomersAsync();
		Task<Customer?> GetCustomerByIdAsync(int customerId);
		Task<Customer> CreateCustomerAsync(Customer customer);
		Task<Customer?> UpdateCustomerAsync(int customerId, Customer customer);
		Task<bool> DeleteCustomerAsync(int customerId);
	}
}