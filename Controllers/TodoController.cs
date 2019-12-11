using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        //Las rutas controladas por controladores se llaman "actions", y son representadas por métodos en la clase controlador.
        //Por ejemplo; el HomeController tiene 3 action methods(Index, About y Contact) que son mapeadas contra estas URLs:
        //localhost:5000/Home -> private Index()
        //localhost:5000/Home/About -> private About()
        //localhost:5000/Home/Contact -> private Contact()
        //Recuerda que los actionMethods son flexibles para devolver tipos, como vistas, JSON data, HTTP status codes(200,401 etc)
        //Este controlador se encargará de recibir los objetos to-do de la DB, ponerlos en el modelo de tal manera que la vista lo entienda
        //y devolver la vista al buscador del usuario.


        public IActionResult Index()
        {
            // Get to-do items from database
            // Put items into a model
            // Render view using the model

        }
    }
}