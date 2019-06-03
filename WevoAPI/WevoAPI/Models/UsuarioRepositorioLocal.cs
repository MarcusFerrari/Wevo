using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WevoAPI.DbModels;

namespace WevoAPI.Models
{
    public class UsuarioRepositorioLocal : IUsuarioRepositorio
    {

        private List<Usuario> usuarios = new List<Usuario>();
        private int id = 1;

        public UsuarioRepositorioLocal()
        {
            AddUsuario(new Usuario { Nome = "Marcus Vinicius", Cpf = "38157999880", Email = "marcus.v.v.ferrari@gmail.com", Telefone = "11 988269035", Sexo = "M", DataNascimento = new DateTime(1989, 9, 22) });
            AddUsuario(new Usuario { Nome = "Caroline Lemos", Cpf = "12345678987", Email = "carol@gmail.com", Telefone = "11111111111", Sexo = "F", DataNascimento = new DateTime(1990, 6, 15) });
        }


        public Usuario AddUsuario(Usuario u)
        {
            u.Id = id++;
            usuarios.Add(u);
            return u;
        }

        public void DeleteUsuario(int id)
        {
            usuarios.RemoveAll(x => x.Id == id);
        }

        public Usuario GetUsuarioById(int id)
        {
            return usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public void Update(Usuario u)
        {
            var index_usuario = usuarios.FindIndex(x => x.Id == u.Id);

            if(index_usuario == -1)
            {
                throw new Exception("Usuário não encontrado para atualização");
            }
            else
            {
                usuarios[index_usuario].Nome = u.Nome;
                usuarios[index_usuario].Cpf = u.Cpf;
                usuarios[index_usuario].Email = u.Email;
                usuarios[index_usuario].Telefone = u.Telefone;
                usuarios[index_usuario].Sexo = u.Sexo;
                usuarios[index_usuario].DataNascimento = u.DataNascimento;
            }

        }
    }
}
