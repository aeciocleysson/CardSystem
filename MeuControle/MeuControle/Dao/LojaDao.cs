using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuControle.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace MeuControle.Dao
{
    public class LojaDao
    {
        string conecta = "SERVER=localhost; DATABASE=meucontrole; UID=root; PWD=3103";
        MySqlConnection conexao = null;
        MySqlCommand comando = null;

        // Método para salvar
        public void salvar(Loja loja)
        {
            conexao = new MySqlConnection(conecta);
            comando = new MySqlCommand("INSERT INTO controle_loja (codigo_loja, nome_loja, tipo_acesso) VALUES (@codLoja, @nome, @tipo)", conexao);

            try
            {
                comando.Parameters.AddWithValue("@codLoja", loja.NumeroLoja);
                comando.Parameters.AddWithValue("@nome", loja.NomeLoja);
                comando.Parameters.AddWithValue("@tipo", loja.TipoAcesso);

                conexao.Open();
                comando.ExecuteNonQuery();


            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }

        }

        // Método para listar as lojas que usam cartão
        public DataTable listarlojaCartao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                comando = new MySqlCommand("SELECT * FROM controle_loja WHERE tipo_acesso like 'CARTAO' ORDER BY codigo_loja", conexao);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);

                return dt;

            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }

        // Método para listar as lojas que usam cracha
        public DataTable listarlojaCracha()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                comando = new MySqlCommand("SELECT * FROM controle_loja WHERE tipo_acesso LIKE 'CRACHA' || tipo_acesso LIKE 'CARTAO/CRACHA' ORDER BY codigo_loja", conexao);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);

                return dt;

            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }

        // Método para atualizar
        public void atualizar(Loja loja)
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                comando = new MySqlCommand("UPDATE controle_loja SET codigo_loja = @codLoja, nome_loja = @nome, tipo_acesso = @tipoAcesso WHERE id = @id", conexao);

                comando.Parameters.AddWithValue("@id", loja.Id);
                comando.Parameters.AddWithValue("@codLoja", loja.NumeroLoja);
                comando.Parameters.AddWithValue("@nome", loja.NomeLoja);
                comando.Parameters.AddWithValue("@tipoAcesso", loja.TipoAcesso);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }

        // Método para buscar a loja pelo numero
        public Loja buscar(int codigoLoja)
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();
                comando = new MySqlCommand("SELECT * FROM controle_loja WHERE codigo_loja = @codLoja", conexao);

                comando.Parameters.AddWithValue("@codLoja", codigoLoja);

                Loja loja = null;

                comando.CommandType = CommandType.Text;

                MySqlDataReader Dr = comando.ExecuteReader();

                while (Dr.Read())
                {
                    loja = new Loja();

                    //loja.Id = Convert.ToInt32(Dr["id"]);

                    loja.NumeroLoja = Convert.ToInt32(Dr["codigo_loja"]);
                    loja.NomeLoja = Convert.ToString(Dr["nome_loja"]);
                    loja.TipoAcesso = Convert.ToString(Dr["tipo_acesso"]);
                }

                return loja;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }

        // Método para excluir uma loja
        public void excluir(Loja loja)
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                comando = new MySqlCommand("DELETE FROM controle_loja WHERE id = @id", conexao);

                comando.Parameters.AddWithValue("@id", loja.Id);

                conexao.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
