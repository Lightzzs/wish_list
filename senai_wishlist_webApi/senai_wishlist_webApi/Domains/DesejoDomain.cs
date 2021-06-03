using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Desejos
    /// </summary>
    public class DesejoDomain
    {
        public int idDesejo { get; set; }
        public int idUsuario { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
    }
}
