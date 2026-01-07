using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Domain.Entities.Usuarios
{
    internal class Usuario
    {
        public Guid Id { get; private set; }
        public string name { get; private set; }
        public string username { get; private set; }
        public string dni { get; private set; }
        private bool estadoActivo = true;


        public Usuario(string name, string username, string dni)
        {
            Id = Guid.NewGuid();
            this.name = name;
            this.username = username;
            this.dni = dni;
            this.estadoActivo = true;


        }

        public bool PuedeUsarElSistema()
        {
            return estadoActivo;
        }

        public void Bloquear()
        {
            if (!estadoActivo)
                throw new InvalidOperationException("El usuario ya está bloqueado");
            estadoActivo = false;
        }

        public void Permitir()
        {
            if(estadoActivo)
                throw new InvalidOperationException("El usuario esta habilitado");
            estadoActivo = true;

        }

        private readonly HashSet<Rol> _roles = new();

        public bool TieneRol(Rol rol)
        {
            return _roles.Contains(rol);
        }

        public void AgregarRol(Rol rol)
        {
            if (_roles.Contains(rol))
                throw new InvalidOperationException("El usuario ya tiene este rol");
            _roles.Add(rol);
        }

        public void QuitarRol(Rol rol)
        {
            if(!_roles.Contains(rol))
            {
                throw new InvalidOperationException("El usuario no tiene este rol");
            }
            if (_roles.Count == 1)
                throw new InvalidOperationException("El usuario no puede quedarse sin roles.");


            _roles.Remove(rol); 

        }
    }
}