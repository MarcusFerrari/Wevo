using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WevoAPI.DbModels;

namespace WevoAPI.Models
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuario AddUsuario(Usuario u)
        {
            try
            {
                wevoContext db = new wevoContext();
                db.Usuario.Add(u);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return u;
        }

        public void DeleteUsuario(int id)
        {
            try
            {
                wevoContext db = new wevoContext();
                var usuario = (from a in db.Usuario
                               where a.Id == id
                               select a).FirstOrDefault();

                if (usuario != null)
                {
                    db.Usuario.Remove(usuario);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Id não encontrado.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario GetUsuarioById(int id)
        {
            try
            {
                wevoContext db = new wevoContext();

                var usuario = (from a in db.Usuario
                               where a.Id == id
                               select a).FirstOrDefault();

                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    throw new Exception("Id não encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            try
            {
                wevoContext db = new wevoContext();

                var usuarios = (from a in db.Usuario
                                select a).ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Usuario u)
        {
            try
            {
                wevoContext db = new wevoContext();

                var usuario = (from a in db.Usuario
                               where a.Id == u.Id
                               select a).FirstOrDefault();

                usuario.Nome = u.Nome;
                usuario.Cpf = u.Cpf;
                usuario.Email = u.Email;
                usuario.Telefone = u.Telefone;
                usuario.Sexo = u.Sexo;
                usuario.DataNascimento = u.DataNascimento;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
