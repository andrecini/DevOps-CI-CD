using DevOps.Core.Enum;
using DevOps.Core.Validator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Core.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set;}
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public Genero Genero { get; set; }

        public Validacao ValidarUsuario()
        {
            var fluentvalidator = new ValidacaoUsuario().Validate(this);
            var validacao = new Validacao();

            if (fluentvalidator.IsValid)
            {
                validacao.EhValido = true;
                validacao.Mensagens = null;
            }
            else
            {
                validacao.EhValido = false;
                validacao.Mensagens = fluentvalidator.Errors.Select(x => x.ErrorMessage.ToString()).ToList();
            }

            return validacao;
        }
    }
}
