using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigitalBankingManagementSystem.Models;

namespace DigitalBankingManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BankAccountController : ControllerBase
	{
		[HttpGet]
		public List<BankAccount> Get() //I'm returning a collection of bankaccount objects
		{
			return new List<BankAccount> //Creating a List , Ex : Empty Basket
			{
				new BankAccount() // Creating a new BankAccount object and adding it to the list
				{
				AccountId = 1,
			AccountNumber = "SBI1001",
			AccountHolderName = "Prapthi",
			Balance = 5000.75M,
			CreatedAt = DateTime.Now,
			IsActive = true
			},
				new BankAccount() {
					 AccountId = 2,
			AccountNumber = "SBI1002",
			AccountHolderName = "Rahul",
			Balance = 12000M,
			CreatedAt = DateTime.Now,
			IsActive = true
				},
				new BankAccount() {
					 AccountId = 3,
			AccountNumber = "SBI1003",
			AccountHolderName = "Ananya",
			Balance = 8000M,
			CreatedAt = DateTime.Now,
			IsActive = false
				}
				/*So, after adding three objects the basket looks like this :
				 * List<BankAccount>
				 * ├── BankAccount #1 (Prapthi)
                   ├── BankAccount #2 (Rahul)
                   └── BankAccount #3 (Ananya) 
				When swagger calls API it receives  all three objects */

			};
		}
	}
}
