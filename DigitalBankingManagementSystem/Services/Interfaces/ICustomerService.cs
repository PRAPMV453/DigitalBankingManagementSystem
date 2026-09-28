using DigitalBankingManagementSystem.DTOs;

namespace DigitalBankingManagementSystem.Services.Interfaces
{
	public interface ICustomerService
	{
		Task<List<CustomerResponseDto>> GetCustomersAsync();

		Task<CustomerResponseDto?> GetCustomerByIdAsync(int customerId);
		Task<CustomerResponseDto> CreateCustomerAsync(CreateCustomerDto customerDto);
		Task<CustomerResponseDto?> UpdateCustomerAsync(int customerId,CreateCustomerDto customerDto);
		Task<bool> DeleteCustomerAsync(int customerId);
	}
}