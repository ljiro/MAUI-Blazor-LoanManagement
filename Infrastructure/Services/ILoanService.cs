using LoanManagement.Core.Models;

namespace LoanManagement.Services;

public interface ILoanService
{
    Task<IEnumerable<Loan>> GetAllLoansAsync(string? searchTerm = null);
    Task<Loan?> GetLoanByIdAsync(string id);
    Task AddLoanAsync(Loan loan);
    Task UpdateLoanAsync(Loan loan);
    Task DeleteLoanAsync(string id);
}