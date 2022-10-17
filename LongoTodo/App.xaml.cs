using System;
using System.Threading.Tasks;
using LongoTodo.Bootstrap;
using LongoTodo.Contracts.Services;
using LongoTodo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LongoTodo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitializeApp();

            InitializeNavigation();
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();
        }

        private void InitializeNavigation()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
