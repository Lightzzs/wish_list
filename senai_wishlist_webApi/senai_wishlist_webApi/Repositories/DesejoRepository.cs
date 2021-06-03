using Microsoft.AspNetCore.Mvc;
using senai_wishlist_webApi.Domains;
using senai_wishlist_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webApi.Repositories
{
    /// <summary>
    /// Classe rensponsavel pelo repositorio dos desejos
    /// </summary>
    public class DesejoRepository : IDesejoRepository
    {
        private string stringConexao = "Data Source=VINICIUS-PC\\SQLEXPRESS; initial catalog=WISHLIST; user Id=sa; pwd=sa@132";
        
        /// <summary>
        /// cadastrar um novo desejo
        /// </summary>
        /// <param name="novoDesejo">Objeto novoDesejo com as informaçoes que serão cadastradas</param>
        /// 
        public void Cadastrar(DesejoDomain novoDesejo)
        {
            // Declara a conexão con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                // Declara a query que será executada
                string queryInsert = "INSERT INTO Desejos(idUsuario, titulo, descricao) VALUES ('" + novoDesejo.idUsuario + "','" + novoDesejo.titulo + "','" + novoDesejo.descricao + "')";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DesejoDomain> ListaTodos()
        {
            // Cria Uma lista listaDesejos onde serão armazenados os dados
            List<DesejoDomain> listaDesejos = new List<DesejoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idUsuario, titulo, descricao FROM Desejos";

                // abre a conexão com banco de dados
                con.Open();

                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão com parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo DesejoDomains
                        DesejoDomain desejo = new DesejoDomain()
                        {
                            // Atribui à propriedade idDesejo o valor da primeira coluna da tabela do banco de dados
                            idDesejo = Convert.ToInt32(rdr[0]),

                            idUsuario = Convert.ToInt32(rdr[0]),
                            
                            // Atribui à propriedade titulo o valor da terceira coluna da tabela do banco de dados
                            titulo = rdr[1].ToString(),

                            // Atribui à propriedad descricao o valor da quarta coluna da tabela do banco de dados
                            descricao = rdr[2].ToString()
                        };

                        // Adiciona o objeto desejo criando a lista listaDesejos
                        listaDesejos.Add(desejo);
                    }
                }
            }

            // retorna a lista de desejos
            return listaDesejos;
        }
    }
}
