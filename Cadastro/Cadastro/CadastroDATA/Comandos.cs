using System.Data;
using System.Data.SqlClient;

namespace CadastroDATA
{
    public class Comandos
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Cadastro;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;

    }
    }
