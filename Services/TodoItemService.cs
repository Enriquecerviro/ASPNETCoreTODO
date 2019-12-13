using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        /// <summary>
        /// The context
        /// DI pattern para injectar "ApplicationDbContext".
        /// </summary>
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user)
        {
            return await _context.Items
                .Where(x => x.IsDone == false && x.UserId == user.Id)
                .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.UserId = user.Id;

            _context.Items.Add(newItem);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;

        }
        /// <summary>
        /// Marks the done asynchronous. Este metodo usa el EFCore para bucar el item por ID en la base de datos. Devuelve nulo si no lo encuentra.
        /// Una vez sabemos si es nulo o no entonces podemos establecer la propiedad IsDone a true y lo devolvemos.
        /// Ademas los cambios solo afectan a la copia local hasta que se persiste con SaveChangesAsync(), este método devuelve un numero que indica cuantas
        /// entidades han sido actualizadas durante la operacion de guardado, EN ESTE CASO SERÁ O '1'(ITEM ACTUALIZADO) O '0'(ALGO FUE MAL).
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> MarkDoneAsync(Guid id, IdentityUser user)
        {
            var item = await _context.Items
                .Where(x => x.Id == id && x.UserId == user.Id)
                .SingleOrDefaultAsync();
            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
                
        }
            
    }       
}           
            