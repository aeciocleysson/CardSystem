using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeuControle.Bll;
using MeuControle.Model;
using MeuControle.Dao;

namespace MeuControle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listar();
            txtNomeLoja.Enabled = false;

        }

        // Método para lompar todos os campos 
        private void limparCampos()
        {
            txtCod.Clear();
            txtNumLoja.Clear();
            txtNomeLoja.Clear();
            cbTipo.SelectedIndex = -1;
            txtNumLoja.Focus();
            btnSalvar.Enabled = true;
            txtNomeLoja.Enabled = false;
            txtNumLoja.Enabled = true;
            txtBuscar.Enabled = true;

        }

        // Método para salvar uma loja nova
        private void salvar(Loja loja)
        {
            LojaBll lojaBll = new LojaBll();

            if (txtNumLoja.Text.Trim() == string.Empty || txtNomeLoja.Text.Trim() == string.Empty || cbTipo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Os campos Codigo Loja, nome Loja e Tipo devem ser preenchidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                loja.NumeroLoja = Convert.ToInt32(txtNumLoja.Text.Trim());
                loja.NomeLoja = txtNomeLoja.Text.Trim();
                loja.TipoAcesso = cbTipo.Text.Trim();

                lojaBll.salvar(loja);

                MessageBox.Show("Registro salvo com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                listar();
            }
        }

        // Método para listar as lojas no datagridview
        private void listar()
        {
            LojaBll lojaBll = new LojaBll();

            dgCartao.DataSource = lojaBll.listarlojaCartao();
            dgCracha.DataSource = lojaBll.listarLojaCracha();

            dgCartao.Columns[0].Visible = false;
            dgCartao.Columns[1].HeaderText = "Cód Loja";
            dgCartao.Columns[2].HeaderText = "Nome Loja";
            dgCartao.Columns[3].HeaderText = "Acesso";

            dgCartao.Columns[2].Width = 199;

            dgCracha.Columns[0].Visible = false;
            dgCracha.Columns[1].HeaderText = "Cód Loja";
            dgCracha.Columns[2].HeaderText = "Nome Loja";
            dgCracha.Columns[3].HeaderText = "Acesso";

            dgCracha.Columns[2].Width = 199;

            // mostra nos textbox a quantidade de lojas cadastradas
            txtCartao.Text = dgCartao.Rows.Count.ToString();
            txtCracha.Text = dgCracha.Rows.Count.ToString();

        }

        // Método para atualizar os dados da loja
        private void atualizar(Loja loja)
        {
            LojaBll lojaBll = new LojaBll();


            if (txtNumLoja.Text.Trim() == string.Empty || txtNomeLoja.Text.Trim() == string.Empty || cbTipo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Os campos Codigo Loja, nome Loja e Tipo devem ser preenchidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                loja.Id = Convert.ToInt32(txtCod.Text.Trim());
                loja.NumeroLoja = Convert.ToInt32(txtNumLoja.Text.Trim());
                loja.NomeLoja = txtNomeLoja.Text.Trim();
                loja.TipoAcesso = cbTipo.Text.Trim();

                lojaBll.atualizar(loja);

                MessageBox.Show("Registro atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                listar();
            }
        }

        // Método para buscar a loja cadastrada quando for digitado o numero da loja no textbox de pesquisa
        private void buscar()
        {
            int codigoLoja = Convert.ToInt32(txtBuscar.Text);

            LojaBll lojaBll = new LojaBll();

            Loja loja = lojaBll.buscar(codigoLoja);

            if (loja != null)
            {
                txtNomeLoja.Text = loja.NomeLoja;
            }
            else
            {
                MessageBox.Show("Loja inexistente!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /* método para verificar se a loja já esta cadastrada
         * se estiver cadastrada vai mostrar a mensagem, 
         * se não estiver cadastrada va colocar o foco no textbox  node da loja
        */
        private void verificarLojaExistente()
        {
            int codigoLoja = Convert.ToInt32(txtNumLoja.Text);

            LojaBll lojaBll = new LojaBll();

            Loja loja = lojaBll.buscar(codigoLoja);

            if (loja != null)
            {
                MessageBox.Show("Loja já cadastrada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtNomeLoja.Enabled = true;
                txtNumLoja.Enabled = false;
                txtNomeLoja.Focus();

            }
        }

        // Método para excluir uma loja
        private void excluir(Loja loja)
        {
            LojaBll lojaBll = new LojaBll();

            if (txtCod.Text == string.Empty)
            {
                MessageBox.Show("Selecione uma loja para ser excluida.");
            }
            else if (MessageBox.Show("Deseja realmente excluir o registro dessa loja?", "Alerta", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                limparCampos();
            }
            else
            {
                loja.Id = Convert.ToInt32(txtCod.Text);
                lojaBll.excluir(loja);

                MessageBox.Show("Loja excluida com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
                listar();
            }

            
        }

        // Botão salvar 
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Loja loja = new Loja();
            salvar(loja);
        }

        // Botão cancelar chamando o método limpar campos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        // Botão atualizar chamando o metodo listar
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            listar();
        }

        // setar os textbox com os dados da linha selecionada do datagridview com um duplo click
        private void dgCartao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSalvar.Enabled = false;
            txtNomeLoja.Enabled = true;
            txtBuscar.Enabled = false;
            txtCod.Text = dgCartao.SelectedCells[0].Value.ToString();
            txtNumLoja.Text = dgCartao.SelectedCells[1].Value.ToString();
            txtNomeLoja.Text = dgCartao.SelectedCells[2].Value.ToString();
            cbTipo.Text = dgCartao.SelectedCells[3].Value.ToString();
        }

        // setar os textbox com os dados da linha selecionada do datagridview com um duplo click
        private void dgCracha_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSalvar.Enabled = false;
            txtNomeLoja.Enabled = true;
            txtBuscar.Enabled = false;
            txtCod.Text = dgCracha.SelectedCells[0].Value.ToString();
            txtNumLoja.Text = dgCracha.SelectedCells[1].Value.ToString();
            txtNomeLoja.Text = dgCracha.SelectedCells[2].Value.ToString();
            cbTipo.Text = dgCracha.SelectedCells[3].Value.ToString();
        }

        // Botão editar chamando o método editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Loja loja = new Loja();
            atualizar(loja);
        }

        // esse evento faz o textbox aceitar somente numeros a tecla apagar e a tecla enter
        private void txtNumLoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)13)
            {
                e.Handled = true;

            }
            else // evento da tecla enter e o metodo que verifica se a loja ja esta cadastrada
                if (e.KeyChar == 13)
                {
                    verificarLojaExistente();
                }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Relatorio relatorio = new Relatorio();
            relatorio.ShowDialog();
        }

        // Buscar a aloja pelo numero
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Loja loja = new Loja();
            excluir(loja);
        }


    }
}
