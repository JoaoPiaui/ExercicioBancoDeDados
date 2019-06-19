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
    public partial class FormColaboradores : Form
    {
        public FormColaboradores()
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
            Colaborador colaboradores = new Colaborador();
            colaboradores.Nome = txtNome.Text;
            colaboradores.Cpf = mtbCpf.Text.ToString();
            colaboradores.Salario = Convert.ToDecimal(mtbSalario.Text);
            colaboradores.Sexo = cbSexo.SelectedItem.ToString();
            colaboradores.Cargo = cbCargo.SelectedItem.ToString();
            colaboradores.Programador = rbProgramador.Checked;

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\BancoDeDados.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO colaboradores 
(nome, cpf, salario,sexo, cargo, programador)
VALUES (@NOME, @CPF, @SALARIO, @SEXO, @CARGO, @PROGRAMADOR)";
            comando.Parameters.AddWithValue("@NOME", colaboradores.Nome);
            comando.Parameters.AddWithValue("@CPF", colaboradores.Cpf);
            comando.Parameters.AddWithValue("@SALARIO", colaboradores.Salario);
            comando.Parameters.AddWithValue("@SEXO", colaboradores.Sexo);
            comando.Parameters.AddWithValue("@CARGO", colaboradores.Cargo);
            comando.Parameters.AddWithValue("@PROGRAMADOR", colaboradores.Programador);

            comando.ExecuteNonQuery();
            MessageBox.Show("Registro criado com sucesso");

            conexao.Close();
        }

        private void Alterar()
        {
            Colaborador colaboradores = new Colaborador();
            colaboradores.Nome = txtNome.Text;
            colaboradores.Cpf = mtbCpf.Text.ToString();
            colaboradores.Salario = Convert.ToDecimal(mtbSalario.Text);
            colaboradores.Sexo = cbSexo.SelectedItem.ToString();
            colaboradores.Cargo = cbCargo.SelectedItem.ToString();
            colaboradores.Programador = rbProgramador.Checked;

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\BancoDeDados.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE colaboradores SET 
nome = @NOME,
cpf = @CPF,
salario = @SALARIO,
sexo = @SEXO,
cargo = @CARGO,
programador = @PROGRAMADOR
WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID",colaboradores.Id);
            comando.Parameters.AddWithValue("@NOME",colaboradores.Nome);
            comando.Parameters.AddWithValue("@CPF",colaboradores.Cpf);
            comando.Parameters.AddWithValue("@SALARIO",colaboradores.Sexo);
            comando.Parameters.AddWithValue("@CARGO",colaboradores.Cargo);
            comando.Parameters.AddWithValue("@PROGRAMADOR",colaboradores.Programador);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        private void AtualizarTabela()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\BancoDeDados.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "@SELECT id, nome,cpf, salario, sexo,cargo, programador FROM colaboradores";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            dgvColaboradores.RowCount = 0;

            for(int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Colaborador colaboradores = new Colaborador();
                colaboradores.Id = Convert.ToInt32(linha["id"]);
                colaboradores.Nome = linha["nome"].ToString();
                colaboradores.Cpf = linha["cpf"].ToString();
                colaboradores.Salario = Convert.ToDecimal(linha["salario"]);
                colaboradores.Sexo = linha["sexo"].ToString();
                colaboradores.Cargo = linha["cargo"].ToString();
                colaboradores.Programador = Convert.ToBoolean(linha["programador"]);
                dgvColaboradores.Rows.Add(new string[] { colaboradores.Id.ToString(), colaboradores.Nome, colaboradores.Cpf.ToString(), colaboradores.Salario.ToString(), colaboradores.Sexo.ToString(), colaboradores.Cargo.ToString(), colaboradores.Programador.ToString()});
            }

            conexao.Close();

        }

        private void FormColaboradores_Activated(object sender, EventArgs e)
        {
        }
    }
}
