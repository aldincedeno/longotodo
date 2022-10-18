using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LongoTodo.Contracts.Services;
using LongoTodo.Models;
using LongoTodo.Extensions;
using Xamarin.Forms;
using System.Windows.Input;
using LongoTodo.Constants;

namespace LongoTodo.ViewModels
{
    public class TodoItemsViewModel: BaseViewModel
    {
        private readonly ITodoItemService _todoItemsService;

        private ObservableCollection<TodoItem> _todoItemsList;
        public ObservableCollection<TodoItem> TodoItemsList
        {
            get
            {
                return _todoItemsList;
            }
            set
            {
                _todoItemsList = value;
                OnPropertyChanged(nameof(TodoItemsList));
            }
        }

        private TodoItem _selectedItem;
        public TodoItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                EditTodoItemCommand.Execute(SelectedItem);
            }
        }

        public ICommand EditTodoItemCommand => new Command(async (todoItem) => await OnEditTodoItemAsync(todoItem));
        public ICommand NewTodoItemCommand => new Command(async () => await OnNewTodoItemAsync());

        public TodoItemsViewModel(INavigationService navigationService,
                                 IDialogService dialogService,
                                 ITodoItemService todoItemService) : base(navigationService, dialogService)
        {
            _todoItemsService = todoItemService;

            InitializeMessenger();
        }

        public override async Task InitAsync()
        {
            TodoItemsList = await GetTodoItemsList();
        }

        private async Task OnEditTodoItemAsync(object todoItem)
        {
            var todo = todoItem as TodoItem;
            await _navigationService.NavigateToAsync<TodoItemDetailViewModel>(todo);
        }

        private async Task OnNewTodoItemAsync()
        {
            await _navigationService.NavigateToAsync<TodoItemDetailViewModel>();
        }

        private async Task<ObservableCollection<TodoItem>> GetTodoItemsList()
        {
            var todoList = await _todoItemsService.GetTodoItemsList();
            return todoList.ToObservableCollection();
        }

        public void InitializeMessenger()
        {
            MessagingCenter.Subscribe<TodoItemDetailViewModel, TodoItem>(this, MessagesKey.NewTodoItem,
                 (sender, todo) => {
                    TodoItemsList.Add(todo);
                });
        }
    }
}
