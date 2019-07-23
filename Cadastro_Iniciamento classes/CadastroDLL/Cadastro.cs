using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadastroDATA;
using System.Data.SqlClient;

namespace CadastroDLL
{
    public class Cadastro
    {
        DAO cdtData = null;
        ContatosData cdtDll = new ContatosData();
        

        public DataTable ExibirDadosDAO()
        {
            try
            {
                DataTable DataT = new DataTable();
                cdtData = new DAO();

                DataT = cdtData.ExibirDados();
                return DataT;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void salvaContato(Contatos contato)
        {
            try
            {
                cdtDll.salvarContatos(contato);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
