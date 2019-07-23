using System.Data;
using System.Data.SqlClient;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CadastroDATA
{
    public class DAO
    {

        string conectaBanco = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Cadastro;Integrated Security=False;User Id=sa;Password=fastsw;MultipleActiveResultSets=True";
        SqlConnection con = null;
        SqlCommand cmd;
        
        int ID = 0;
        
        //metodo para conectar no banco
        public void abrirConexao()
        {
            try
            {
                con = new SqlConnection(conectaBanco);
                con.Open();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //metodo para desconectar do banco

            public void fecharConexao()
        {
            try
            {
                con = new SqlConnection(conectaBanco);
                con.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirDados()
        {
            try
            {
                con = new SqlConnection(conectaBanco);
                cmd = new SqlCommand("Select * from contatos", con);

                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                DataTable dtable = new DataTable();

                adapt.Fill(dtable);
                return dtable;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
    }
