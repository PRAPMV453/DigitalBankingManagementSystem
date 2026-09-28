namespace DigitalBankingManagementSystem.Models
{
	public class BankAccount
	{
		public int AccountId { get; set; }
		public string AccountNumber { get; set; }
		public string AccountHolderName { get; set; }
		public decimal Balance { get; set; }
		public DateTime CreatedAt { get; set; }

		public bool IsActive { get; set; }
	}
}
