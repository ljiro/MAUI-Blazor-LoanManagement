using LoanManagement.Web.Stores.Loans.Actions;
using LoanManagement.Web.Stores.Loans.State;
using Fluxor;

namespace LoanManagement.Web.Stores.Loan.Reducers;

public static class LoanReducers
{
    [ReducerMethod]
    public static LoanState OnFetchLoans(LoanState state, FetchLoansAction action)
    {
        return new LoanState(
            isLoading: true,
            loans: state.Loans,
            selectedLoan: state.SelectedLoan,
            errorMessage: null,
            searchTerm: action.SearchTerm ?? string.Empty
        );
    }

    [ReducerMethod]
    public static LoanState OnFetchLoansSuccess(LoanState state, FetchLoansSuccessAction action)
    {
        return new LoanState(
            isLoading: false,
            loans: action.Loans,
            selectedLoan: state.SelectedLoan,
            errorMessage: null,
            searchTerm: state.SearchTerm
        );
    }

    [ReducerMethod]
    public static LoanState OnFetchLoansFailure(LoanState state, FetchLoansFailureAction action)
    {
        return new LoanState(
            isLoading: false,
            loans: state.Loans,
            selectedLoan: state.SelectedLoan,
            errorMessage: action.ErrorMessage,
            searchTerm: state.SearchTerm
        );
    }
}