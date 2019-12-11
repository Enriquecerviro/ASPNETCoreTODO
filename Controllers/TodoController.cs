using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Controllers
//Las rutas controladas por controladores se llaman "actions", y son representadas por métodos en la clase controlador.
//Por ejemplo; el HomeController tiene 3 action methods(Index, About y Contact) que son mapeadas contra estas URLs:
//localhost:5000/Home -> private Index()
//localhost:5000/Home/About -> private About()
//localhost:5000/Home/Contact -> private Contact()
//Recuerda que los actionMethods son flexibles para devolver tipos, como vistas, JSON data, HTTP status codes(200,401 etc)
//Este controlador se encargará de recibir los objetos to-do de la DB, ponerlos en el modelo de tal manera que la vista lo entienda
//y devolver la vista al buscador del usuario.
{
    /// <summary>
    /// Como este controlador solo depende de la interfaz que a su vez es "un array de objetos Todo" y no depende
    /// de una clase en especifico le da igual cual sea la clase, siempre y cuando coincida
    /// con la interface.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class TodoController : Controller
    {
        /// <summary>
        /// The todo item service. Mantenemos una referencia a la interfaz del to-do.
        /// Asi podemos usar el servicio desde el Index action method
        /// </summary>
        private readonly ITodoItemService _todoItemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoController"/> class.
        /// Este constructor me permite crear una nueva instancia de la clase, lo consigo
        /// añadiendo el param "ITodoItemService" al constructor, ordenando así
        /// que para crear un Todocontroller vamos a necesitar un objeto que coincida con la interfaz.
        /// </summary>
        /// <param name="todoItemService">The todo item service.</param>
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
       
        public async Task<IActionResult> Index()
        {
            var items = await _todoItemService.GetIncompleteItemsAsync();
           
            var model = new TodoViewModel()
            {
                Items = items
            };
            return View(model);

        }
    }
}