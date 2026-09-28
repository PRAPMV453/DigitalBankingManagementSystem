namespace DigitalBankingManagementSystem.DTOs
{
	public class CustomerResponseDto
	{
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string? LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateOnly? DateOfBirth { get; set; }
		public string? Address { get; set; }
		public DateTime? CreateDate { get; set; }
	}
}