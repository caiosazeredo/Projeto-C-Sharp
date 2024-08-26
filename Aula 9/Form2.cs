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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Loaderinicial.Chamartabelas(listViewClientes);
            ClienteCarregador.CarregarClientes(listViewClientes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica se há algum item selecionado no ListView
            if (listViewClientes.SelectedItems.Count > 0)
            {
                // Pega o ID do usuário selecionado (primeira coluna do ListView)
                string UsuarioID = listViewClientes.SelectedItems[0].SubItems[0].Text;

                string strConexao = "server=localhost;uid=root;database=bancodedados1";
                MySqlConnection conexao = new MySqlConnection(strConexao);

                try
                {
                    // Abre a conexão com o banco de dados
                    conexao.Open();

                    // Exclui os registros relacionados ao usuário na tabela 'usuarioperfil' usando JOIN
                    string queryDeletePerfil = $@"
                DELETE usuarioperfil 
                FROM usuarioperfil 
               JOIN usuarios ON usuarioperfil.PerfilID = usuarios.UsuarioID 
                WHERE usuarios.UsuarioID = {UsuarioID}";

                    MySqlCommand cmdDeletePerfil = new MySqlCommand(queryDeletePerfil, conexao);
                    cmdDeletePerfil.ExecuteNonQuery(); // Executa a exclusão dos perfis relacionados ao usuário

                    // Exclui o usuário da tabela 'usuarios' baseado no 'UsuarioID'
                    string queryDeleteUsuario = $"DELETE FROM usuarios WHERE UsuarioID = {UsuarioID}";
                    MySqlCommand cmdDeleteUsuario = new MySqlCommand(queryDeleteUsuario, conexao);

                    // Executa o comando de exclusão do usuário
                    int linhasAfetadas = cmdDeleteUsuario.ExecuteNonQuery();

                    // Verifica se o registro foi excluído com sucesso
                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Cliente excluído com sucesso!");
                        // Atualiza a lista de clientes no ListView após a exclusão
                        ClienteCarregador.CarregarClientes(listViewClientes);
                    }
                    else
                    {
                        MessageBox.Show("Falha ao excluir o usuário.");
                    }

                    // Fecha a conexão com o banco de dados
                    conexao.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir o usuário: {ex.Message}");
                }
            }
            else
            {
                // Exibe uma mensagem caso nenhum usuário tenha sido selecionado
                MessageBox.Show("Por favor, selecione um usuário para excluir.");
            }
        }



        private void listViewClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


