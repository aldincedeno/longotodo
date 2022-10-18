using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LongoTodo.Models;

namespace LongoTodo.Contracts.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsList();
        Task<TodoItem> CreateTodoItem(TodoItem todoItem);
        Task<TodoItem> UpdateTodoItem(TodoItem todoItem);
        Task<bool> DeleteTodoItem(TodoItem todoItem);
    }
}
