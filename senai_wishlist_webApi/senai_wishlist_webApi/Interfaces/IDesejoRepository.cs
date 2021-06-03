using senai_wishlist_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webApi.Interfaces
{
    /// <summary>
    /// Interface rensponsável pelo repositório DesejoRepository
    /// </summary>
    interface IDesejoRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// Lista Todos os Desejos
        /// </summary>
        /// <returns>retorna uma lista de desejos</returns>
        List<DesejoDomain> ListaTodos();

        /// <summary>
        /// Cadastra um novo desejo
        /// </summary>
        /// <param name="novoDesejo">Objeto novoDesejo com as informaçoes que serão cadastradas</param>
        void Cadastrar(DesejoDomain novoDesejo);

    }
}
