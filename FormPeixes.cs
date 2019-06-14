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
            if(lblId.Text == "0")
            {
                Inserir();
            }
            else
            {
                Alterar();
            }
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

        private void Alterar()
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
            comando.CommandText = @"UPDATE peixes SET
nome = @NOME,
raca = @RACA,
preco = @PRECO,
quantidade = @QUANTIDADE
WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", peixe.Id);
            comando.Parameters.AddWithValue("@NOME", peixe.Nome);
            comando.Parameters.AddWithValue("@RACA", peixe.Raca);
            comando.Parameters.AddWithValue("@PRECO", peixe.Preco);
            comando.Parameters.AddWithValue("@QUANTIDADE", peixe.Quantidade);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        private void AtualizaTabela()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "@SELECT id, nome, raca, preco, quantidade FROM peixes";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            dgvPeixes.RowCount = 0;

            for(int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Peixe peixe = new Peixe();
                peixe.Id = Convert.ToInt32(linha["id"]);
                peixe.Nome = linha["nome"].ToString();
                peixe.Raca = linha["raca"].ToString();
                peixe.Preco = Convert.ToDecimal(linha["preco"]);
                peixe.Quantidade = Convert.ToInt32(linha["quantidade"]);
                dgvPeixes.Rows.Add(new string[] { peixe.Id.ToString(), peixe.Nome, peixe.Raca.ToString(), peixe.Preco.ToString(), peixe.Quantidade.ToString()});
            }
        }
    }
}
