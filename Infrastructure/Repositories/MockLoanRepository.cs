using LoanManagement.Core.Models;

namespace LoanManagement.Infrastructure.Repositories;

public class MockLoanRepository : ILoanRepository
{
    private readonly List<Loan> _loans = new()
    {
        new Loan {
            Id = "LN001",
            ClientName = "Juan Dela Cruz",
            Type = LoanType.Personal,
            Amount = 50000,
            Status = LoanStatus.Approved,
            RemainingBalance = 42000
        },
        new Loan {
            Id = "LN002",
            ClientName = "Maria Santos",
            Type = LoanType.Business,
            Amount = 150000,
            Status = LoanStatus.Pending
        }
    };

    public Task AddAsync(Loan loan)
    {
        _loans.Add(loan);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string id)
    {
        var loan = _loans.FirstOrDefault(l => l.Id == id);
        if (loan != null) _loans.Remove(loan);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Loan>> GetAllAsync() => Task.FromResult(_loans.AsEnumerable());

    public Task<Loan?> GetByIdAsync(string id) =>
        Task.FromResult(_loans.FirstOrDefault(l => l.Id == id));

    public Task UpdateAsync(Loan loan)
    {
        var index = _loans.FindIndex(l => l.Id == loan.Id);
        if (index >= 0) _loans[index] = loan;
        return Task.CompletedTask;
    }
}