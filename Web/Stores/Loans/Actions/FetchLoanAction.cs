using LoanManagement.Core.Models; 

namespace LoanManagement.Web.Stores.Loans.Actions;

public class FetchLoansAction
{
    public string? SearchTerm { get; }

    public FetchLoansAction(string? searchTerm = null)
    {
        SearchTerm = searchTerm;
    }
}

public class FetchLoansSuccessAction
{
    private IEnumerable<Core.Models.Loan> loans;

    public IEnumerable<Loan> Loans { get; }

    public FetchLoansSuccessAction(IEnumerable<Loan> loans)
    {
        Loans = loans;
    }

    public FetchLoansSuccessAction(IEnumerable<Core.Models.Loan> loans)
    {
        this.loans = loans;
    }
}

public class FetchLoansFailureAction
{
    public string ErrorMessage { get; }

    public FetchLoansFailureAction(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}