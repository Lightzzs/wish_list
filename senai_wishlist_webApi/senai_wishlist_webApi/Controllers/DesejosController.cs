using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_wishlist_webApi.Domains;
using senai_wishlist_webApi.Interfaces;
using senai_wishlist_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
///  Controller rensponsável pelos endpoints referentes aos Desejos
/// </summary>
namespace senai_wishlist_webApi.Controllers
{
    // define que tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class DesejosController : ControllerBase
    {
        /// <summary>
        /// Objeto _desejoRepository que irá receber todos os metodos definidos na interface IDesejoRepository
        /// </summary>
        private IDesejoRepository _desejoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _desejoRepository para que haja a referencia aos métodos no repositorio
        /// </summary>
        public DesejosController()
        {
            _desejoRepository = new DesejoRepository();
        }

        /// <summary>
        /// lista todos os desejos
        /// </summary>
        /// <returns>uma lista de generos e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaDesejos para receber os dados
            List<DesejoDomain> listaDesejo = _desejoRepository.ListaTodos();

            // Retorna o status code 200 (Ok) com a lista de generos no formato JSON
            return Ok(listaDesejo);
        }
        /// <summary>
        /// Cadastrar um novo desejo
        /// </summary>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5000/api/desejos
        [HttpPost]

        public IActionResult Post(DesejoDomain novoDesejo)
        {
            // Faz a chamada para o método .Cadastrar()
            _desejoRepository.Cadastrar(novoDesejo);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }
    }
}
