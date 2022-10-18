using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LongoTodo.Bootstrap;
using LongoTodo.Contracts.Services;
using LongoTodo.ViewModels;
using LongoTodo.Views;
using Xamarin.Forms;

namespace LongoTodo.Services
{
    /*
    Servicio que implementa la navegación entre los diferentes formularios, ViewModel to ViewModel
    */
    public class NavigationService: INavigationService
    {
        private readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
            await NavigateToAsync<TodoItemsViewModel>();
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage != null)
                await CurrentApplication.MainPage.Navigation.PopAsync();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public async Task PopToRootAsync()
        {
            await CurrentApplication.MainPage.Navigation.PopToRootAsync();
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter, object sender = null)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            var navigationPage = CurrentApplication.MainPage as NavigationPage;

            if (navigationPage != null)
            {
                await navigationPage.PushAsync(page);
            }
            else
            {
                CurrentApplication.MainPage = new NavigationPage(page);
            }

            if (parameter != null)
                await (page.BindingContext as BaseViewModel).InitAsync(parameter);
            else
                await (page.BindingContext as BaseViewModel).InitAsync();
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            try
            {
                Page page = Activator.CreateInstance(pageType) as Page;
                BaseViewModel viewModel = AppContainer.Resolve(viewModelType) as BaseViewModel;
                viewModel.Page = page;
                viewModel.Navigation = page.Navigation;
                page.BindingContext = viewModel;

                return page;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(TodoItemsViewModel), typeof(TodoItemsPage));
            _mappings.Add(typeof(TodoItemDetailViewModel), typeof(TodoItemDetailPage));
        }
    }
}
