﻿using Dapper;
using JogadorAPI.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace JogadorAPI.Repositories
{
    public class UsuarioRepository : Repository<Usuario>
    {
        private readonly MySqlConnection _connection;

        public UsuarioRepository(MySqlConnection connection) : base(connection)
            => _connection = connection;

        public dynamic Create(Usuario usuario)
        {
            string sql = @"INSERT INTO Usuario 
                               (EMAIL, TELEFONE, CPF, NOME, SENHA, CIDADE, BAIRRO) 
                           VALUES 
                               (@Email, @Telefone, @CPF, @Nome, @Senha, @Cidade, @Bairro)";

            var data = new
            {
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                CPF = usuario.CPF,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Cidade = usuario.Cidade,
                Bairro = usuario.Bairro
            };

            var rowsAffected = _connection.Execute(sql, data);
            return rowsAffected;
        }
    }
}
