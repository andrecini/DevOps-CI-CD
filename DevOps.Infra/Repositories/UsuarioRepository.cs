using Dapper;
using DevOps.Core.Models;
using DevOps.Infra.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MySqlConnection _connection; 

        public UsuarioRepository(MySqlConnection connection) 
        {
            _connection = connection;
        }

        public bool AdicionarUsuario(Usuario usuario)
        {
            var query = 
            @"INSERT INTO Usuario (Nome, Sobrenome, Idade, Genero)
            VALUES (@Nome, @Sobrenome, @Idade, @Genero);";

            return _connection.Execute(query, usuario) > 0;
        }

        public bool AtualizarUsuario(Usuario usuario)
        {
            var query =
            @"UPDATE Usuario
            SET Nome = @Nome,
                Sobrenome = @Sobrenome,
                Idade = @Idade,
                Genero = @Genero
            WHERE Id = @Id;";

            return _connection.Execute(query, usuario) > 0;
        }

        public bool RemoverUsuario(int id)
        {
            var query =
            @"DELETE FROM Usuario
            WHERE Id = @Id;";

            return _connection.Execute(query, new { Id = id }) > 0;
        }

        public Usuario SelecionarUsuarioPorId(int id)
        {
            var query =
            @"SELECT Id, Nome, Sobrenome, Idade, Genero
            FROM Usuario
            WHERE Id = @Id;";

            return _connection.QueryFirst<Usuario>(query, new { Id = id });
        }

        public IEnumerable<Usuario> SelecionarUsuarios()
        {
            var query =
            @"SELECT Id, Nome, Sobrenome, Idade, Genero
            FROM Usuario";

            return _connection.Query<Usuario>(query);
        }
    }
}
