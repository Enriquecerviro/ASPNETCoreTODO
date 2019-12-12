using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Models
{
    /// <summary>
    /// Esta clase defino lo necesario para almacenar este objeto en la DB
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Gets or sets the identifier.Guid es globally unique identifier. Es una práctica común usar guids para ids.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is done.Por defecto estará en false para todos los nuevos productos.
        /// Una vez el usuario clicke el checkbox cambiará a true.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is done; otherwise, <c>false</c>.
        /// </value>
        public bool IsDone { get; set; }
        /// <summary>
        /// Gets or sets the tittle. El titulo del objeto To-Do no pueder estar vacío ni ser nulo.
        /// </summary>
        /// <value>
        /// The tittle.
        /// </value>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the due at.
        /// </summary>
        /// <value>
        /// The due at.
        /// </value>
        [UIHint("DTO")]
        public DateTimeOffset? DueAt { get; set; }
    }
}
