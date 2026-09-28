using DigitalBankingManagementSystem.DTOs;
using DigitalBankingManagementSystem.Models;
using DigitalBankingManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBankingManagementSystem.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCustomers()
		{
			var customers = await _customerService.GetCustomersAsync();

			return Ok(customers);
		}
		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCustomerById(int id)
		{
			var customer = await _customerService.GetCustomerByIdAsync(id);
			if (customer == null)
			{
				return NotFound();
			}
			return Ok(customer);
		}
		[Authorize(Roles = "Admin")]
		[HttpGet("admin-test")]
		public IActionResult AdminTest()
		{
			return Ok(new
			{
				message = "You are authorized as Admin"
			});
		}
		[HttpPost]
		public async Task<IActionResult> CreateCustomer(CreateCustomerDto customerDto)
		{
			var createdCustomer = await _customerService.CreateCustomerAsync(customerDto);

			return CreatedAtAction(
				nameof(GetCustomerById),
				new { id = createdCustomer.CustomerId },
				createdCustomer);
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCustomer(
	int id,
	CreateCustomerDto customerDto)
		{
			var updatedCustomer =
				await _customerService.UpdateCustomerAsync(id, customerDto);

			if (updatedCustomer == null)
			{
				return NotFound();
			}

			return Ok(updatedCustomer);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			var deleted = await _customerService.DeleteCustomerAsync(id);

			if (!deleted)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}