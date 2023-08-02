using DevOps.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevOps.Test.Core.Models
{
    public class TesteValidacao
    {
        [Fact]
        public void ValidacaoEhValido_OK()
        {
            // Arrange
            var validacao = new Validacao
            {
                EhValido = true,
                Mensagens = null
            };

            // Assert
            Assert.True(validacao.EhValido);
            Assert.Null(validacao.Mensagens);
        }

        [Fact]
        public void ValidacaoEhInvalido_OK()
        {
            // Arrange
            var validacao = new Validacao
            {
                EhValido = false,
                Mensagens = new List<string> { "Erro 1", "Erro 2" }
            };

            // Assert
            Assert.False(validacao.EhValido);
            Assert.NotNull(validacao.Mensagens);
            Assert.Equal(2, validacao.Mensagens.Count);
        }

        [Fact]
        public void ValidacaoEhInvalido_ERRO()
        {
            // Arrange
            var validacao = new Validacao
            {
                EhValido = false,
                Mensagens = null
            };

            // Assert
            Assert.False(validacao.EhValido);
            Assert.Null(validacao.Mensagens);
        }
    }
}
