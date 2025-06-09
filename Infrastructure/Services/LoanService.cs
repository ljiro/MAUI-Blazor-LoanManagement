using LoanManagement.Core.Models;
using LoanManagement.Infrastructure.Repositories;

namespace LoanManagement.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _repository;

    public LoanService(ILoanRepository repository)
    {
        _repository = repository;
    }

    public async Task AddLoanAsync(Loan loan) => await _repository.AddAsync(loan);

    public async Task DeleteLoanAsync(string id) => await _repository.DeleteAsync(id);

    public async Task<IEnumerable<Loan>> GetAllLoansAsync(string? searchTerm = null)
    {
        var loans = await _repository.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            loans = loans.Where(l =>
                l.ClientName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                l.Id.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        return loans;
    }

    public async Task<Loan?> GetLoanByIdAsync(string id) =>
        await _repository.GetByIdAsync(id);

    public async Task UpdateLoanAsync(Loan loan) =>
        await _repository.UpdateAsync(loan);
}