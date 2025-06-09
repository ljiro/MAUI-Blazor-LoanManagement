using LoanManagement.Core.Models;

namespace LoanManagement.Infrastructure.Repositories;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAllAsync();
    Task<Loan?> GetByIdAsync(string id);
    Task AddAsync(Loan loan);
    Task UpdateAsync(Loan loan);
    Task DeleteAsync(string id);
}