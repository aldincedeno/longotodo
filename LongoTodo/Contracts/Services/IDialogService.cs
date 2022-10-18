using System;
using System.Threading.Tasks;

namespace LongoTodo.Contracts.Services
{
    public interface IDialogService
    {
        Task ShowDialogAsync(string message, string title, string buttonLabel);

        Task<bool> ShowConfirmAsync(string message, string title, string okText, string cancelText);

        void ShowToast(string message);
    }
}
