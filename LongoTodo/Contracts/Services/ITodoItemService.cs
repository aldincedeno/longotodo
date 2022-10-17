﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LongoTodo.Models;

namespace LongoTodo.Contracts.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsList();
    }
}