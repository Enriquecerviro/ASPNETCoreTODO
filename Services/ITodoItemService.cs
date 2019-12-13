using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        /// <summary>
        /// Gets the incomplete items asynchronous.
        /// El tipo "Task" es parecido a las promesas, y lo usamos porque vamos a hacer uso
        /// de un metodo que será asíncrono, es decir, antes de devolver la lista de todo-items
        /// tiene que hablar con la DB.
        /// </summary>
        /// <returns></returns>
        Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user);

        Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user);

        Task<bool> MarkDoneAsync(Guid id, IdentityUser user);
    }
}
