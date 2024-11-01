
using Microsoft.AspNetCore.Mvc;
using ApiUser.Models;


namespace ApiUser.Controllers
{
    [ApiController]
    //Route é usado para definir como a URL de requisição da API será montada

    // Exemplo de Requisição para essa API
    // http://localhost:{porta onde API está executando}/api/usuario/{passar o Id do usuário desejado para ações de Inclusão, Atualização e Exclusão}
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        // Tabela de usuários para simulação
        private static readonly Dictionary<int, string> usuarios = new Dictionary<int, string>
        {
            { 1, "Usuário Teste 1" },
            { 2, "Usuário Teste 2" },
            { 3, "Usuário Teste 3" },
            { 4, "Usuário Teste 4" }
        };

        // Método para selecionar User por ID
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            
            if (usuarios.ContainsKey(id))
            {
                return Ok(new Usuario { Id = id, Nome = usuarios[id] });
            }
            else
            {
                return NotFound(new { Error = "Usuário não encontrado" });
            }
        }

        // Método para adicionar um Usuário
        [HttpPost]
        public ActionResult<Usuario> AdicionarUsuario([FromBody] Usuario usuario)
        {
            if (usuarios.ContainsKey(usuario.Id))
            {
                return Conflict(new { Error = "Usuário com esse ID já existe" });
            }

            usuarios[usuario.Id] = usuario.Nome;

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // Método para atualizar um usuário
        [HttpPut("{id}")]
        public ActionResult<Usuario> AtualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (!usuarios.ContainsKey(id))
            {
                return NotFound(new { Error = "Usuário não encontrado" });
            }

            usuarios[id] = usuario.Nome;

            return Ok(new Usuario { Id = id, Nome = usuarios[id] });
        }

        // Método para deletar um usuário
        [HttpDelete("{id}")]
        public ActionResult DeletarUsuario(int id)
        {
            if (!usuarios.ContainsKey(id))
            {
                return NotFound(new { Error = "Usuário não encontrado" });
            }

            // Remove o usuário do dicionário
            usuarios.Remove(id);

            // Retorna um status 204 No Content para indicar que a remoção foi bem-sucedida
            return NoContent();
        }
    }
}