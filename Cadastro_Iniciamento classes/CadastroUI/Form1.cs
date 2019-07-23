using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadastroDATA;
using System.Data.SqlClient;
using CadastroDATA;
using CadastroDLL;

namespace CadastroUI
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=Cadastro;Integrated Security=False;User Id=sa;Password=fastsw;MultipleActiveResultSets=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;


        public Form1()
        {
            InitializeComponent();
            ExibirDados();

        }

        public void ExibirDados()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("SELECT * FROM Contatos", con);
                adapt.Fill(dt);
                dgvAgenda.DataSource = dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salvar(Contatos contato)
        {
            CadastroDLL.Cadastro cdtDLL = new CadastroDLL.Cadastro();

            contato.Nome = txtNome.Text.ToUpper();
            contato.Endereco = txtEndereco.Text.ToUpper();
            contato.Telefone = txtTelefone.Text.ToUpper();
            contato.Celular = txtCelular.Text.ToUpper();
            contato.Email = txtEmail.Text.ToUpper();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contatos contato = new Contatos();
            salvar(contato);
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text != "" && txtCelular.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("UPDATE Contatos SET nome=@nome, endereco=@endereco, celular=@celular,telefone=@telefone,email=@email WHERE id=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToLower());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro atualizado com sucesso...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
                finally
                {
                    con.Close();
                    ExibirDados();
                    LimparDados();
                }
            }
            else
            {
                MessageBox.Show("Informe todos os dados requeridos");
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtNome.Focus();
        }

        private void DgvAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            CadastroDLL.Cadastro cdtDLL = new CadastroDLL.Cadastro();
            try
            {
                dgvAgenda.DataSource = cdtDLL.ExibirDadosDAO();  
            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro ao exibir os dados" + erro);
            }
          
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja Sair do programa ?", "Agenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                txtNome.Focus();
            }

        }
        private void LimparDados()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            ID = 0;
        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                if (MessageBox.Show("Deseja Deletar este registro ?", "Agenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cmd = new SqlCommand("DELETE Contatos WHERE id=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("registro deletado com sucesso...!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro : " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                        ExibirDados();
                        LimparDados();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para deletar");
            }
        }
    }
 
}
