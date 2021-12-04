using FluentValidation;
using System.Text.RegularExpressions;
using ValidaSenha.Model;

namespace ValidaSenha.Util
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            //https://pt.stackoverflow.com/questions/373574/regex-para-senha-forte
            /*

            Nove ou mais caracteres
            Ao menos 1 dígito
            Ao menos 1 letra minúscula
            Ao menos 1 letra maiúscula
            Ao menos 1 caractere especial
            Considere como especial os seguintes caracteres: !@#$%^&*()-+
            Não possuir caracteres repetidos dentro do conjunto

            /^
              (?=.*\d)                                  // deve conter ao menos um dígito
              (?=.*[a-z])                               // deve conter ao menos uma letra minúscula
              (?=.*[A-Z])                               // deve conter ao menos uma letra maiúscula
              (?=.*[!@#$%^&*()-+-])                      // deve conter ao menos um caractere especial -> !@#$%^&*()-+
              (?:([0-9a-zA-Z!@#$%^&*()-+-])(?!\1)){9,}   // deve conter ao menos 9 dos caracteres mencionados, sem repeticao
            $/

            */

            RuleFor(x => x.Senha)
                .NotEmpty()
                .Matches(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()-+-])(?:([0-9a-zA-Z!@#$%^&*()-+-])(?!\1)){9,}$", RegexOptions.IgnoreCase);
        }
    }
}
