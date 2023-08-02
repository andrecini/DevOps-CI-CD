using Dapper;
using DevOps.Core.Enum;
using DevOps.Core.Models;
using DevOps.Infra.Interfaces;
using DevOps.Infra.Repositories;
using Moq;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevOps.Test.Infra.Repositories
{
    public class TesteUsuarioRepository
    {
        private Mock<IUsuarioRepository> mock;

        public TesteUsuarioRepository()
        {
            mock = new Mock<IUsuarioRepository>();
        }

        [Fact]
        public void AdicionarUsuario_OK()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "João",
                Sobrenome = "Silva",
                Idade = 30,
                Genero = Genero.Masculino
            };

            mock.Setup(x => x.AdicionarUsuario(usuario)).Returns(true);

            // Act
            var resultado = mock.Object.AdicionarUsuario(usuario);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void AdicionarUsuario_ERRO()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "João",
                Sobrenome = "Silva",
                Idade = 30,
                Genero = Genero.Masculino
            };

            mock.Setup(x => x.AdicionarUsuario(usuario)).Returns(false);

            // Act
            var resultado = mock.Object.AdicionarUsuario(usuario);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void AtualizarUsuario_OK()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "João",
                Sobrenome = "Silva",
                Idade = 30,
                Genero = Genero.Masculino
            };

            mock.Setup(x => x.AtualizarUsuario(usuario)).Returns(true);

            // Act
            var resultado = mock.Object.AtualizarUsuario(usuario);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void AtualizarUsuario_ERRO()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "João",
                Sobrenome = "Silva",
                Idade = 30,
                Genero = Genero.Masculino
            };

            mock.Setup(x => x.AtualizarUsuario(usuario)).Returns(false);

            // Act
            var resultado = mock.Object.AtualizarUsuario(usuario);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void RemoverUsuario_OK()
        {
            // Arrange
            var id = 1;

            mock.Setup(x => x.RemoverUsuario(id)).Returns(true);

            // Act
            var resultado = mock.Object.RemoverUsuario(id);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void RemoverUsuario_ERRO()
        {
            // Arrange
            var id = 1;

            mock.Setup(x => x.RemoverUsuario(id)).Returns(false);

            // Act
            var resultado = mock.Object.RemoverUsuario(id);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void SelecionarUsuarios_OK()
        {
            // Arrange
            IEnumerable<Usuario> usuarios = new List<Usuario>
            {
                new Usuario
                {
                    Id = '1',
                    Nome = "João",
                    Sobrenome = "Silva",
                    Idade = 30,
                    Genero = Genero.Masculino
                },
                new Usuario
                {
                    Id = '2',
                    Nome = "Maria",
                    Sobrenome = "Silva",
                    Idade = 28,
                    Genero = Genero.Feminino
                },
                new Usuario
                {
                    Id = '3',
                    Nome = "Lady",
                    Sobrenome = "Silva",
                    Idade = 16,
                    Genero = Genero.Outro
                },
            };

            mock.Setup(x => x.SelecionarUsuarios()).Returns(usuarios);

            // Act
            var resultado = mock.Object.SelecionarUsuarios();

            // Assert
            Assert.NotNull(resultado);
        }

        [Fact]
        public void SelecionarUsuarios_ERRO()
        {
            // Arrange
            IEnumerable<Usuario> usuarios = null;
            mock.Setup(x => x.SelecionarUsuarios()).Returns(usuarios);

            // Act
            var resultado = mock.Object.SelecionarUsuarios();

            // Assert
            Assert.Null(resultado);
        }

        [Fact]
        public void SelecionarUsuarioPorId_OK()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "João",
                Sobrenome = "Silva",
                Idade = 30,
                Genero = Genero.Masculino
            };

            mock.Setup(x => x.SelecionarUsuarioPorId(1)).Returns(usuario);

            // Act
            var resultado = mock.Object.SelecionarUsuarios();

            // Assert
            Assert.NotNull(resultado);
        }

        [Fact]
        public void SelecionarUsuarioPorId_ERRO()
        {
            // Arrange
            Usuario usuario = null;

            mock.Setup(x => x.SelecionarUsuarioPorId(100)).Returns(usuario);

            // Act
            var resultado = mock.Object.SelecionarUsuarioPorId(100);

            // Assert
            Assert.Null(resultado);
        }
    }
}
