// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*
 * Primero usamos JQuery para adjuntar codigo en el evento click a todos los elementos html que tengan una clase CSS llamada 'done-checkbox',
 * cuando se clicka el checkbox entonces markCompleted() se inicia
 * La funcion markCompleted() hace lo siguiente:
 *      Primero: añade el atributo 'disabled' para que no pueda ser marcada de nuevo.
 *      Segundo: añadimos la clase CSS 'done' al elemento padre que contiene el checkbox, lo cual cambia la manera en la que luce la fila.
 *      Tercero: enviamos formulario.
 */
$(document).ready(function () {
    $('.done-checkbox').on('click', function (e) {
        markCompleted(e.target);
    });
});

function markCompleted(checkbox) {
    checkbox.disabled = true;

    var row = checkbox.closest('tr');
    $(row).addClass('done');

    var form = checkbox.closest('form');
    form.submit();
}
