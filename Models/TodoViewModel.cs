using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Models
{
    public class TodoViewModel
    {
        /// <summary>
        /// Gets or sets the items.Nuestra clase representa un solo item pero puede ser que necesite pintar 1,2 o 1000.
        /// Por esta razon, la vista modelo debería estar separada de la clase que alberga el array de objetos.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public TodoItem[] Items { get; set; }
    }
}
