using LoanManagement.Services;
using LoanManagement.Web.Stores.Loans.Actions;
using Fluxor;
using IDispatcher = Fluxor.IDispatcher;
namespace LoanManagement.Web.Stores.Loan.Effects;

public class LoanEffects
{
    private readonly ILoanService _loanService;

    public LoanEffects(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [EffectMethod]
    public async Task HandleFetchLoans(FetchLoansAction action, IDispatcher dispatcher)
    {
        try
        {
            var loans = await _loanService.GetAllLoansAsync(action.SearchTerm);
            dispatcher.Dispatch(new FetchLoansSuccessAction(loans));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new FetchLoansFailureAction(ex.Message));
        }
    }
}