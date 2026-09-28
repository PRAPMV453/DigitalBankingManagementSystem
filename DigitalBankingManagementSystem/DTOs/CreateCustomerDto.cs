using System.ComponentModel.DataAnnotations;

namespace DigitalBankingManagementSystem.DTOs
{
	public class CreateCustomerDto
	{
		[Required]
		[StringLength(50)]
		public string FirstName { get; set; } = string.Empty;

		[StringLength(50)]
		public string? LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		[Phone]
		public string Phone { get; set; } = string.Empty;

		public DateOnly? DateOfBirth { get; set; }

		[StringLength(255)]
		public string? Address { get; set; }

		[Required]
		public string PasswordHash { get; set; } = string.Empty;
	}
}