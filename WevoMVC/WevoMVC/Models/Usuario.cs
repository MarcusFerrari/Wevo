using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WevoMVC.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("CPF")]
        [MaxLength(14)]
        public string Cpf { get; set; }
        [MaxLength(200)]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [MaxLength(13)]
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        [DisplayName("Data de Nasc.")]
        public DateTime? DataNascimento { get; set; }
    }
}
