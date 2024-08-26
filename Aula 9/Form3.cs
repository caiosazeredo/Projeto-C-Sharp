using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula_9
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtem os valores dos TextBoxes
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string salario = textBox3.Text;
            string dataCriacao = DateTime.Now.ToString("yyyy-MM-dd");
            string status = "Ativo";

            string strConexao = "server=localhost;uid=root;database=bancodedados1";
            MySqlConnection conexao = new MySqlConnection(strConexao);

            try
            {
                conexao.Open();

                string query = $"INSERT INTO usuarios (nome, email, DataCriacao, Status) VALUES ('{nome}', '{email}', '{dataCriacao}', '{status}')";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                int linhasAfetadas = cmd.ExecuteNonQuery();


                if (linhasAfetadas > 0)
                {

                    long usuarioID = cmd.LastInsertedId;


                    string querySalario = $"INSERT INTO usuarioperfil (PerfilID, salario) VALUES ('{usuarioID}', '{salario}')";
                    MySqlCommand cmdSalario = new MySqlCommand(querySalario, conexao);
                    cmdSalario.ExecuteNonQuery();

                    MessageBox.Show("Dados inseridos com sucesso!");

                    ClienteCarregador.CarregarClientes(listViewClientes);
                }
                else
                {
                    MessageBox.Show("Falha ao inserir dados.");
                }

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Loaderinicial.Chamartabelas(listViewClientes);

            // Carrega os usuários na ListView usando o método da classe ClienteCarregador
            ClienteCarregador.CarregarClientes(listViewClientes);
        }

        private void listViewClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

