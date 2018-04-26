using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuControle.Model;
using MeuControle.Dao;
using System.Data;

namespace MeuControle.Bll
{
    public class LojaBll
    {
        // Método para salvar
        public void salvar(Loja loja)
        {
            try
            {
                LojaDao lojaDao = new LojaDao();

                lojaDao.salvar(loja);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        // Método para listar as lojas que usam cartão
        public DataTable listarlojaCartao()
        {
            try
            {
                LojaDao lojaDao = new LojaDao();

                DataTable dt = new DataTable();

                dt = lojaDao.listarlojaCartao();

                return dt;

            }
            catch (Exception erro)
            {

                throw erro;
            }
        }


        // Método para listar as lojas que usam cracha
        public DataTable listarLojaCracha()
        {
            try
            {
                LojaDao lojaDao = new LojaDao();

                DataTable dt = new DataTable();

                dt = lojaDao.listarlojaCracha();

                return dt;

            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        // Método para atualizar
        public void atualizar(Loja loja)
        {
            try
            {
                LojaDao lojaDao = new LojaDao();
                lojaDao.atualizar(loja);
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
        }

        // Método para buscar a loja pelo numero
        public Loja buscar(int codigoLoja)
        {
            Loja loja = null;
            LojaDao lojaDao = new LojaDao();

            try
            {
                loja = new Loja();
                    
                loja = lojaDao.buscar(codigoLoja);

                return loja;
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
        }

        // Método para excluir uma loja
        public void excluir(Loja loja)
        {
            try
            {
                LojaDao lojaDao = new LojaDao();
                lojaDao.excluir(loja);
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
        }
    }
}
