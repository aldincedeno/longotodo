using System;
using System.Threading.Tasks;
using LongoTodo.ViewModels;

namespace LongoTodo.Contracts.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateBackAsync();

        Task PopToRootAsync();
    }
}
