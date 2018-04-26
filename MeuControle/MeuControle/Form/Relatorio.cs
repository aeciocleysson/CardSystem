using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuControle
{
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
            
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'meucontroleDataSet.controle_loja' table. You can move, or remove it, as needed.
            this.controle_lojaTableAdapter.Fill(this.meucontroleDataSet.controle_loja);


            this.reportViewer1.RefreshReport();
        }
    }
}
