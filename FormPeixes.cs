using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercicio01
{
    public partial class FormPeixes : Form
    {
        public FormPeixes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
                Inserir();
        }

        private void Inserir()
        {
            Peixe peixe = new Peixe();
            peixe.Nome = txtNome.Text;
            peixe.Raca = cbRaca.SelectedItem.ToString();
            peixe.Preco = Convert.ToDecimal(mtbPreco.Text);
            peixe.Quantidade = Convert.ToInt32(nudQuantidade.Value);

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\ExercicioBancoDeDados.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO peixes 
(nome, preco, raca, quantidade)
VALUES (@NOME, @PRECO, @RACA, @QUANTIDADE)";
            comando.Parameters.AddWithValue("@NOME", peixe.Nome);
            comando.Parameters.AddWithValue("@PRECO", peixe.Preco);
            comando.Parameters.AddWithValue("@RACA", peixe.Raca);
            comando.Parameters.AddWithValue("@QUANTIDADE", peixe.Quantidade);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro criado com sucesso");
            conexao.Close();
        }
    }
}
