namespace LoanManagement.Core.Models;

public class Loan
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ClientName { get; set; } = string.Empty;
    public LoanType Type { get; set; }
    public string Purpose { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
    public string Duration { get; set; } = "12 months";
    public LoanStatus Status { get; set; } = LoanStatus.Pending;
    public string InterestRate { get; set; } = "12%";
    public decimal RemainingBalance { get; set; }
    public string NextPayment { get; set; } = string.Empty;
    public string ValidatedBy { get; set; } = string.Empty;
    public int CreditScore { get; set; } = 75;
    public int CoApplicantNumber { get; set; }
    public int GuarantorNumber { get; set; }
}

public enum LoanStatus
{
    Pending,
    Approved,
    Rejected,
    Active,
    Completed,
    Defaulted
}

public enum LoanType
{
    Personal,
    Business,
    Emergency,
    Mortgage
}