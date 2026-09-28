using System;
using System.Collections.Generic;

namespace DigitalBankingManagementSystem.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
