using FornecedoresAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FornecedoresAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        List<Fornecedor> _createdInMemory;
        public FornecedorController()
        {
            _createdInMemory = GenerateFornecedores();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> ObterFornecedor()
        {
            var fornecedores = _createdInMemory.ToList();
            if (fornecedores.Any())
            {
                return fornecedores;
            }
                return NotFound();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> ObterFornecedorPorId(string id)
        {
            var fornecedores = _createdInMemory.ToList();
            if (fornecedores.Any() )
            {
                return fornecedores.FirstOrDefault();
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Cadastrar(Fornecedor fornecedor)
        {
            if(!ValidaFornecedor(fornecedor))
            return BadRequest();
            _createdInMemory.Add(fornecedor);
            return Created("",fornecedor.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Editar(string id, Fornecedor fornecedor)
        {
            
            Guid fornecedorId;
            bool id_ok = Guid.TryParse(id, out fornecedorId);
            if (!id_ok || string.IsNullOrEmpty(id) || fornecedorId != fornecedor.Id)
                return BadRequest();
            var fornecedor_banco = _createdInMemory.FindIndex(f => f.Id == fornecedorId);
        }

        private bool ValidaFornecedor(Fornecedor fornecedor)
        {
            return true;
        }

        private List<Fornecedor> GenerateFornecedores()
        {
           var fornecedores = new List<Fornecedor>
            {
                new Fornecedor()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Fornecedor A",
                    Cnpj = "123.456.789-0001/12",
                    Telefone = "(41)9555-1234",
                    Email = "email@teste.com"
                }
            };
        fornecedores[0].Enderecos = new List<Endereco>
            {
                new Endereco
                {
                    Id = Guid.NewGuid(),
                    Rua = "Rua Rio Parana",
                    Numero = "854",
                    Complemento = "304",
                    Cidade = "Pinhais",
                    Estado = "Paraná",
                    Pais = "Brasil"
                }
            };
            fornecedores.Add(new Fornecedor()
            {
                Nome = "Fornecedor b",
                Cnpj = "987.654.321-0001/98",
                Telefone = "(41)9555-9876",
                Email = "email@testing.com"
            });
            fornecedores[1].Enderecos = new List<Endereco>
                {
                    new Endereco
                    {
                        Rua = "Rua Coronel Enock de Lima",
                        Numero = "77",
                        Complemento = "",
                        Cidade = "Curitiba",
                        Estado = "Paraná",
                        Pais = "Brasil"
                    }
                };
            return fornecedores; 
        }
    }
}
