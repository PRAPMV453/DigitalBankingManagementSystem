using DigitalBankingManagementSystem.Data;
using DigitalBankingManagementSystem.Models;
using DigitalBankingManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalBankingManagementSystem.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly BankingDbContext _context;

		public CustomerRepository(BankingDbContext context)
		{
			_context = context;
		}

		public async Task<List<Customer>> GetCustomersAsync()
		{
			return await _context.Customers.ToListAsync();
		}
		public async Task<Customer?> GetCustomerByIdAsync(int customerId)
		{
			return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
		}
		public async Task<Customer> CreateCustomerAsync(Customer customer)
		{
			await _context.Customers.AddAsync(customer);
			await _context.SaveChangesAsync();

			return customer;
		}
		public async Task<Customer?> UpdateCustomerAsync(int customerId, Customer customer)
		{
			var existingCustomer = await _context.Customers
				.FirstOrDefaultAsync(c => c.CustomerId == customerId);

			if (existingCustomer == null)
			{
				return null;
			}

			existingCustomer.FirstName = customer.FirstName;
			existingCustomer.LastName = customer.LastName;
			existingCustomer.Email = customer.Email;
			existingCustomer.Phone = customer.Phone;
			existingCustomer.DateOfBirth = customer.DateOfBirth;
			existingCustomer.Address = customer.Address;

			await _context.SaveChangesAsync();

			return existingCustomer;
		}
		public async Task<bool> DeleteCustomerAsync(int customerId)
		{
			var customer = await _context.Customers
				.FirstOrDefaultAsync(c => c.CustomerId == customerId);

			if (customer == null)
			{
				return false;
			}

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();

			return true;
		}
	}
}