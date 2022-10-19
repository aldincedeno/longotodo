using System;
using System.Threading.Tasks;
using System.Windows.Input;
using LongoTodo.Constants;
using LongoTodo.Contracts.Services;
using LongoTodo.Models;
using Xamarin.Forms;

namespace LongoTodo.ViewModels
{
    public class TodoItemDetailViewModel: BaseViewModel
    {
        private readonly ITodoItemService _todoItemsService;

        private TodoItem _todoItem;

        private string _nameItem;
        public string NameItem
        {
            get
            {
                return _nameItem;
            }
            set
            {
                _nameItem = value;
                OnPropertyChanged(nameof(NameItem));
            }
        }

        public ICommand CreateItemCommand => new Command(async () => await OnCreateItemAsync());

        public TodoItemDetailViewModel(INavigationService navigationService,
                                 IDialogService dialogService,
                                 ITodoItemService todoItemService): base(navigationService, dialogService)
        {
            _todoItemsService = todoItemService;
        }

        public override Task InitAsync()
        {
            NameItem = "";

            return base.InitAsync();
        }
        public override Task InitAsync(object data)
        {
            _todoItem = (data as TodoItem);

            NameItem = _todoItem?.Name;

            return base.InitAsync(data);
        }

        private async Task OnCreateItemAsync()
        {            
            if (string.IsNullOrEmpty(NameItem))
            {
                await _dialogService.ShowDialogAsync("Name is required", "Warning!", "OK");
                return;
            }

            if (_todoItem == null)
            {
                var todo = new TodoItem {
                    Name = NameItem,
                    IsCompleted = false
                };

                _todoItem = await _todoItemsService.CreateTodoItem(todo);

                MessagingCenter.Send(this, MessagesKey.NewTodoItem, todo);
                await _navigationService.NavigateBackAsync();
            }
            else
            {
                _todoItem.Name = NameItem;
                await _todoItemsService.UpdateTodoItem(_todoItem);
            }
        }
    }
}
