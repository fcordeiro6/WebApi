using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Models
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private List<Contato> contatos = new List<Contato>();
        static private SqlConnection sqlConn;
            
        public ContatoRepositorio()
        {
            string connectionString = "server=FABIO-PC\\SQLEXPRESS; Database=test;Integrated Security=SSPI;";
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
        }

        public IEnumerable<Contato> GetAll(int size, int page)
        {
            int offset = page * size;
            string sql = "SELECT * FROM tbcontato ORDER BY ID OFFSET " + offset + " ROWS FETCH NEXT " + size + " ROWS ONLY";
            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            SqlDataReader dr = cmd.ExecuteReader();

            contatos.Clear();
            
            while (dr.Read())
            {
                Contato contato = new Contato();
                contato.id = dr[0].ToString();
                contato.nome = dr[1].ToString();
                contato.canal = dr[2].ToString();
                contato.valor = dr[3].ToString();
                contato.obs = dr[4].ToString();
                contatos.Add(contato);
            }
            dr.Close();
            return contatos;
        }

        public Contato Get(string id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbcontato where id = " + id, sqlConn);
            SqlDataReader dr = cmd.ExecuteReader();
            

            Contato contato = new Contato();
            if (!dr.Read())
            {
                contato = null;
            } else
            {
                contato.id = dr[0].ToString();
                contato.nome = dr[1].ToString();
                contato.canal = dr[2].ToString();
                contato.valor = dr[3].ToString();
                contato.obs = dr[4].ToString();
            }
            dr.Close();      
            return contato;
        }
        public Boolean Add(Contato contato)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbcontato (nome, canal, valor, obs) values (" +
                "'" + contato.nome + "'" + ", " + "'" + contato.canal + "'" + ", " +
                "'" + contato.valor + "'" + ", " + "'" + contato.obs + "'" + ")", sqlConn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            } else
            {
                return false;
            }
            
        }
        public Boolean Remove(string id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbcontato where id = " + id, sqlConn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(string id, Contato contato)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbcontato SET " +
                "nome = " + "'" + contato.nome + "'" + ", " +
                "canal = " + "'" + contato.canal + "'" + ", " + 
                "valor = " + "'" + contato.valor + "'" + ", "  +
                "obs = " + "'" + contato.obs + "'" +
                " where id = " + id, sqlConn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}