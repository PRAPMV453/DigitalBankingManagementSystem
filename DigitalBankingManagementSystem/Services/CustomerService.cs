using DigitalBankingManagementSystem.DTOs;
using DigitalBankingManagementSystem.Models;
using DigitalBankingManagementSystem.Repositories.Interfaces;
using DigitalBankingManagementSystem.Services.Interfaces;

namespace DigitalBankingManagementSystem.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public async Task<List<CustomerResponseDto>> GetCustomersAsync()
		{
			var customers = await _customerRepository.GetCustomersAsync();

			return customers.Select(c => new CustomerResponseDto
			{
				CustomerId = c.CustomerId,
				FirstName = c.FirstName,
				LastName = c.LastName,
				Email = c.Email,
				Phone = c.Phone,
				DateOfBirth = c.DateOfBirth,
				Address = c.Address,
				CreateDate = c.CreateDate // Fixed the property name to match the Customer class
			}).ToList();
		}
		public async Task<CustomerResponseDto?> GetCustomerByIdAsync(int customerId)
		{
			var customer = await _customerRepository.GetCustomerByIdAsync(customerId);

			if (customer == null)
				return null;

			return new CustomerResponseDto
			{
				CustomerId = customer.CustomerId,
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				Email = customer.Email,
				Phone = customer.Phone,
				DateOfBirth = customer.DateOfBirth,
				Address = customer.Address,
				CreateDate = customer.CreateDate // Fixed the property name to match the Customer class
			};
		}
		public async Task<CustomerResponseDto> CreateCustomerAsync(CreateCustomerDto customerDto)
		{
			var customer = new Customer
			{
				FirstName = customerDto.FirstName,
				LastName = customerDto.LastName,
				Email = customerDto.Email,
				Phone = customerDto.Phone,
				DateOfBirth = customerDto.DateOfBirth,
				Address = customerDto.Address,
				PasswordHash = customerDto.PasswordHash
			};

			var createdCustomer = await _customerRepository.CreateCustomerAsync(customer);

			return new CustomerResponseDto
			{
				CustomerId = createdCustomer.CustomerId,
				FirstName = createdCustomer.FirstName,
				LastName = createdCustomer.LastName,
				Email = createdCustomer.Email,
				Phone = createdCustomer.Phone,
				DateOfBirth = createdCustomer.DateOfBirth,
				Address = createdCustomer.Address,
				CreateDate = createdCustomer.CreateDate
			};
		}
		public async Task<CustomerResponseDto?> UpdateCustomerAsync(int customerId,CreateCustomerDto customerDto)
		{
			var customer = new Customer
			{
				FirstName = customerDto.FirstName,
				LastName = customerDto.LastName,
				Email = customerDto.Email,
				Phone = customerDto.Phone,
				DateOfBirth = customerDto.DateOfBirth,
				Address = customerDto.Address,
				PasswordHash = customerDto.PasswordHash
			};

			var updatedCustomer =
				await _customerRepository.UpdateCustomerAsync(customerId, customer);

			if (updatedCustomer == null)
			{
				return null;
			}

			return new CustomerResponseDto
			{
				CustomerId = updatedCustomer.CustomerId,
				FirstName = updatedCustomer.FirstName,
				LastName = updatedCustomer.LastName,
				Email = updatedCustomer.Email,
				Phone = updatedCustomer.Phone,
				DateOfBirth = updatedCustomer.DateOfBirth,
				Address = updatedCustomer.Address,
				CreateDate = updatedCustomer.CreateDate
			};
		}
		public async Task<bool> DeleteCustomerAsync(int customerId)
		{
			return await _customerRepository.DeleteCustomerAsync(customerId);
		}
	}
}