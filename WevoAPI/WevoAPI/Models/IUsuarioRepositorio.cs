using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WevoAPI.DbModels;

namespace WevoAPI.Models
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioById(int id);
        Usuario AddUsuario(Usuario u);
        void DeleteUsuario(int id);
        void Update(Usuario u);
    }
}
