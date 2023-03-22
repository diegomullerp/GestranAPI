using System.ComponentModel.DataAnnotations;

namespace FornecedoresAPI.Models
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get;set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }

        public Fornecedor() { }

        public Fornecedor(string nome, string cnpj, string telefone, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
        }
    }
}
