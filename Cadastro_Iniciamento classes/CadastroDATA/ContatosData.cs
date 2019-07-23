using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CadastroDATA
{
    public class ContatosData : DAO
    {

        SqlCommand cmd = null;
        SqlConnection con = null;
        public void salvarContatos(Contatos contato)
        {
            try
            {
                abrirConexao();
                cmd = new SqlCommand("Insert into contatos (nome,endereco,celular,telefone,email) values (@nome, @endereco, @celular, @telefone, @email)",con);
                cmd.Parameters.AddWithValue("@nome", contato.Nome);
                cmd.Parameters.AddWithValue("@endereco", contato.Endereco);
                cmd.Parameters.AddWithValue("@celular", contato.Celular);
                cmd.Parameters.AddWithValue("@telefone", contato.Telefone);
                cmd.Parameters.AddWithValue("@email", contato.Email);
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                fecharConexao();
            }
        }

        public void atualizaContatos(Contatos contato)
        {
            try
            {
                cmd = new SqlCommand("UPDATE Contatos SET nome=@nome, endereco=@endereco, celular=@celular,telefone=@telefone,email=@email WHERE id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", contato.Id);
                cmd.Parameters.AddWithValue("@nome", contato.Nome);
                cmd.Parameters.AddWithValue("@endereco", contato.Endereco);
                cmd.Parameters.AddWithValue("@celular", contato.Celular);
                cmd.Parameters.AddWithValue("@telefone", contato.Telefone);
                cmd.Parameters.AddWithValue("@email", contato.Email);
            }
            catch
            {

            }
        }

    }
}
