using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LongoTodo.Contracts.Services;
using Xamarin.Forms;

namespace LongoTodo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Page Page { get; set; }

        protected readonly INavigationService _navigationService;

        public INavigation Navigation { get; set; }

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual Task InitAsync()
        {
            return Task.FromResult(false);
        }

        public virtual Task InitAsync(object data)
        {
            return Task.FromResult(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
