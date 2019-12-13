using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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
    [Authorize]
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

        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoController"/> class.
        /// Este constructor me permite crear una nueva instancia de la clase, lo consigo
        /// añadiendo el param "ITodoItemService" al constructor, ordenando así
        /// que para crear un Todocontroller vamos a necesitar un objeto que coincida con la interfaz.
        /// </summary>
        /// <param name="todoItemService">The todo item service.</param>
        public TodoController(ITodoItemService todoItemService,
            UserManager<IdentityUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null) return Challenge();

            var items = await _todoItemService.GetIncompleteItemsAsync(currentUser);

            var model = new TodoViewModel()
            {
                Items = items
            };
            return View(model);
        }
        /// <summary>
        /// Indexes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(TodoItem item)
        {
            return View(item);
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="newItem">The new item.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null) return Challenge();
            var successful = await _todoItemService.AddItemAsync(newItem, currentUser );

            if (!successful)
            {
                return BadRequest("couldnt add item");
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Marks the done.
        /// Since you aren't using model binding, there's no ModelState to check for
        /// validity.Instead, you can check the guid value directly to make sure it's
        /// valid.If for some reason the id parameter in the request was missing or
        /// couldn't be parsed as a guid, id will have a value of Guid.Empty . If
        /// that's the case, the action tells the browser to redirect to /Todo/Index and refresh the page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if( id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var currentUser = await _userManager.GetUserAsync(User);

            var successful = await _todoItemService.MarkDoneAsync(id, currentUser);
            if (!successful)
            {
                return BadRequest("couldnt load a shit");
            }
            return RedirectToAction("Index");
        }
    }
}