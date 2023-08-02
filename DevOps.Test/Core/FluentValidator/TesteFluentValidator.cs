using DevOps.Core.Enum;
using DevOps.Core.Models;
using DevOps.Core.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevOps.Test.Core.FluentValidator
{
    public class TesteFluentValidator
    {
        [Fact]
        public void Validado_OK()
        {
            // Arrange
            var validator = new ValidacaoUsuario();
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "João",
                Sobrenome = "Silva",
                Idade = 30,
                Genero = Genero.Masculino
            };

            // Act
            var valido = validator.Validate(usuario);

            // Assert
            Assert.True(valido.IsValid);
            Assert.Empty(valido.Errors);
        }

        [Fact]
        public void Validado_ERROR()
        {
            // Arrange
            var validator = new ValidacaoUsuario();
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "",
                Sobrenome = "Silva",
                Idade = 150,
                Genero = (Genero)4
            };

            // Act
            var valido = validator.Validate(usuario);

            // Assert
            Assert.False(valido.IsValid);
            Assert.NotEmpty(valido.Errors);
        }

        [Fact]
        public void Mensagens_OK()
        {
            var validator = new ValidacaoUsuario();
            var usuario = new Usuario
            {
                Id = -1,
                Nome = "",
                Sobrenome = "",
                Idade = 150,
                Genero = (Genero)4
            };

            // Act
            var erros = validator.Validate(usuario).Errors.Select(x => x.ErrorMessage);

            // Assert
            Assert.Contains("Especifique o Nome do Usuário.", erros);
            Assert.Contains("Especifique o Sobrenome do Usuário.", erros);
            Assert.Contains("A Idade informada não é válida.", erros);
            Assert.Contains("Especifique o Gênero do Usuário.", erros);

        }
    }
}
