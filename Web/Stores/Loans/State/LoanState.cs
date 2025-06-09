using Fluxor;

using LoanManagement.Core.Models;

namespace LoanManagement.Web.Stores.Loans.State;

[FeatureState]
public class LoanState
{
    public bool IsLoading { get; } = false;
    public IEnumerable<Loan> Loans { get; } = Enumerable.Empty<Loan>();
    public Loan? SelectedLoan { get; } = null;
    public string? ErrorMessage { get; } = null;
    public string SearchTerm { get; } = string.Empty;

    private LoanState() { } // Required for creating initial state
    
    public LoanState(
        bool isLoading, 
        IEnumerable<Loan> loans, 
        Loan? selectedLoan, 
        string? errorMessage,
        string searchTerm)
    {
        IsLoading = isLoading;
        Loans = loans;
        SelectedLoan = selectedLoan;
        ErrorMessage = errorMessage;
        SearchTerm = searchTerm;
    }
}