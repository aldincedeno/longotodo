using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LongoTodo.Contracts.Services;

namespace LongoTodo.Services
{
    public class DialogService : IDialogService
    {
        public Task<bool> ShowConfirmAsync(string message, string title, string okText, string cancelText)
        {
            return UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText);
        }

        public Task ShowDialogAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public void ShowToast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }
    }
}
