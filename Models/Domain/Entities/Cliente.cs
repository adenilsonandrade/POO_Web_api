using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_API.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Cliente() { }

        public Cliente(string Nome, string Email, string Telefone, string Endereco)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Telefone = Telefone;
            this.Endereco = Endereco;
        }
    }
}