using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        /// <summary>
        /// Pegar a lista de todas as pessoas 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Pessoa> GetListas()
        {
            var _dbContext = new _DbContext();
            var vLista = _dbContext.Pessoa.ToList();

            return vLista;
        }

        /// <summary>
        /// Pegar os dados de uma pessoa especifica
        /// </summary>
        /// <param name="id">ID da Pessoa</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Pessoa GetPessoa(int id)
        {
            //Instanciar o banco de Dados
            var _DbContext = new _DbContext();

            //Selecionar a Pessoa pelo id 
            //var vPessoa = _DbContext.Pessoa.Where(p => p.Id == id ).FirstOrDefault();

            var vPessoa = _DbContext.Pessoa.Find(id);

            //Retorna os Dados
            return vPessoa;
        }

        [HttpPost]
        public Pessoa inserir(Pessoa pessoa)
        {

            var _dbContext = new _DbContext();


            _dbContext.Pessoa.Add(pessoa);
            _dbContext.SaveChanges();

            return pessoa;
        }

        [HttpPut]
        public Pessoa Alterar(Pessoa pessoa)
        {
            var _dbContext = new _DbContext();


            _dbContext.Pessoa.Entry(pessoa).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return pessoa;
        }

        [HttpDelete("{id}")]

        public ActionResult Remover(int id)
        {

            //instanciar o banco de dados
            var _dbContext = new _DbContext();

            //localizar o registro a ser removido pelo id 
            var vPessoa = _dbContext.Pessoa.Find(id);

            //Remover o registro encontrado
            _dbContext.Pessoa.Remove(vPessoa);

            //Salvar alterações
            _dbContext.SaveChanges();

            return Ok();



            return Ok();
        }
    }
}
