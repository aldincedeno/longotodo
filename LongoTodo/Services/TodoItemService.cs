using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using LongoTodo.Constants;
using LongoTodo.Contracts.Repository;
using LongoTodo.Contracts.Services;
using LongoTodo.Models;

namespace LongoTodo.Services
{
    /*
    Servicio que implementa las operaciones que se pueden realizar sobre los todoItems: Crear, Actualizar y Borrar
    */
    public class TodoItemService: ITodoItemService
    {
        private readonly IGenericRepository _genericRepository;

        public TodoItemService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.AppServiceUrl)
            {
                Path = ApiConstants.TodoListEndPoint,
                Port = -1,
            };

            var query = HttpUtility.ParseQueryString(builder.Query);
            builder.Query = query.ToString();

            string url = builder.ToString();

            var item = await _genericRepository.PostAsync(url, todoItem);

            return item;
        }

        public async Task<bool> DeleteTodoItem(TodoItem todoItem)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.AppServiceUrl)
            {
                Path = ApiConstants.TodoListEndPoint,
                Port = -1,
            };

            var query = HttpUtility.ParseQueryString(builder.Query);
            builder.Query = query.ToString();

            string url = builder.ToString();

            bool item = await _genericRepository.DeleteAsync(url, todoItem.Id);

            return item;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsList()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.AppServiceUrl)
            {
                Path = ApiConstants.TodoListEndPoint,
                Port = -1,
            };

            var query = HttpUtility.ParseQueryString(builder.Query);
            builder.Query = query.ToString();

            string url = builder.ToString();

            var todoItems = await _genericRepository.GetAsync<List<TodoItem>>(url);

            //List<TodoItem> todoItems = new List<TodoItem>();
            //todoItems.Add(new TodoItem { Id = Guid.NewGuid().ToString(), IsCompleted = false, Name = "Test Local" });

            return todoItems;
        }

        public async Task<TodoItem> UpdateTodoItem(TodoItem todoItem)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.AppServiceUrl)
            {
                Path = ApiConstants.TodoListEndPoint,
                Port = -1,
            };

            var query = HttpUtility.ParseQueryString(builder.Query);
            builder.Query = query.ToString();

            string url = builder.ToString();

            var item = await _genericRepository.PostAsync(url, todoItem);

            return item;
        }
    }
}
