using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDATA
{
    public class Contatos
    {
        int id;
        string nome, endereco, celular, telefone, email;

        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
