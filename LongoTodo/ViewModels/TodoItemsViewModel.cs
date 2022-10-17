using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LongoTodo.Contracts.Services;
using LongoTodo.Models;
using LongoTodo.Extensions;

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

        public TodoItemsViewModel(INavigationService navigationService,
                                 ITodoItemService todoItemService) : base(navigationService)
        {
            _todoItemsService = todoItemService;
        }

        public override async Task InitAsync()
        {
            TodoItemsList = await GetTodoItemsList();
        }

        private async Task<ObservableCollection<TodoItem>> GetTodoItemsList()
        {
            var todoList = await _todoItemsService.GetTodoItemsList();
            return todoList.ToObservableCollection();
        }
    }
}
