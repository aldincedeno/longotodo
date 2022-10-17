﻿using System;
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
    public class TodoItemService: ITodoItemService
    {
        private readonly IGenericRepository _genericRepository;

        public TodoItemService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
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

            //var todoItems = await _genericRepository.GetAsync<List<TodoItem>>(url);

            List<TodoItem> todoItems = new List<TodoItem>();
            todoItems.Add(new TodoItem { Id = Guid.NewGuid().ToString(), IsCompleted = false, Name = "Test Local" });

            return todoItems;
        }
    }
}