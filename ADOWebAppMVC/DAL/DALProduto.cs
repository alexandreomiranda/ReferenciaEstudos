using ADOWebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ADOWebAppMVC.DAL
{
    public class DALProduto : IGenericCRUD<Produto>
    {
        string conexao = WebConfigurationManager.ConnectionStrings["ADOWebAppMVC"].ConnectionString;

        public List<Produto> Get()
        {
            string sqlCommand = "Select * FROM Produto ORDER BY Nome";
            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sqlCommand, conn);
                List<Produto> dados = new List<Produto>();
                Produto p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Produto();
                            p.ProdutoId = (int)reader["ProdutoID"];
                            p.Nome = reader["Nome"].ToString();
                            p.Preco = (decimal)reader["Preco"];
                            p.Estoque = (int)reader["Estoque"];
                            dados.Add(p);
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return dados;
            }
        }

        public Produto GetById(int id = 0)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "Select * FROM Produto WHERE ProdutoId = @cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", id);
                Produto p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }
                        p = new Produto();
                        p.ProdutoId = (int)reader["ProdutoId"];
                        p.Nome = reader["Nome"].ToString();
                        p.Preco = (decimal)reader["Preco"];
                        p.Estoque = (int)reader["Estoque"];
                    }
                }
                catch (Exception)
                {
                    conn.Close();
                }
                return p;
            }
        }

        public void Cadastra(Produto obj)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "INSERT INTO Produto (Nome, Preco, Estoque) VALUES (@nome, @preco, @estoque)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco", obj.Preco);
                cmd.Parameters.AddWithValue("@estoque", obj.Estoque);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void Atualiza(Produto obj)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "UPDATE Produto SET Nome=@nome, Preco=@preco, Estoque=@estoque Where ProdutoId=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", obj.ProdutoId);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco", obj.Preco);
                cmd.Parameters.AddWithValue("@estoque", obj.Estoque);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void Exclui(int id)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "DELETE Produto Where ProdutoId=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }

            }
        }
    }
}