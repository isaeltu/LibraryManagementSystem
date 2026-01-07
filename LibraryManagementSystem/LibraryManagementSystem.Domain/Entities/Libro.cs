using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Domain.Entities
{
    internal class Libro
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string ISBN { get; private set; }
        public bool Disponible { get; private set; }

        public Libro(string titulo, string isbn)
        {
            Id = Guid.NewGuid();
            this.Titulo = titulo;
            this.ISBN = isbn;
            Disponible = true;  
        }

        public void marcarComoPrestado()
        {
            if (!Disponible)
                throw new InvalidOperationException("El libro no esta disponible");
            Disponible = false;
        }


        public void marcarDevuelto()
        {
            Disponible = true;
        }
    }

    
}
