namespace FornecedoresAPI.Models
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public Endereco() { }

        public Endereco(string rua, string numero, string complemento, string cidade, string estado, string pais)
        {
            Id = Guid.NewGuid();
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }
    }
}
