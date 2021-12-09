using FluentValidation;
using System.Globalization;
using System.Text;
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
              (?=.*[!@#$%^&*()-+-])                     // deve conter ao menos um caractere especial -> !@#$%^&*()-+
            $/

            */

            Transform(from: x => x.Senha, to: value => value.Replace(" ", ""))
                .MinimumLength(9);


            RuleFor(x => x.Senha)
                .NotNull()
                .NotEmpty()
                .Matches(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()-+-])")
                .Must(NaoPossuiCaracterRepetidoConsecutivoOuNoConjunto);
               

        }

        private bool NaoPossuiCaracterRepetidoConsecutivoOuNoConjunto(Usuario usuario, string senha)
        {
            bool naoPossuiCaracterReptido;
            int quantidade = 0;

            for (int i = 0; i < senha.Length; i++)
            {
                string caracter = senha[i].ToString();
                quantidade = 1;

                for (int j = i + 1; j < senha.Length; j++)
                {

                    if (string.Compare(caracter, senha[j].ToString(), true, CultureInfo.CurrentCulture) == 0)
                    {
                        quantidade++;
                    }

                    if (quantidade > 1)
                    {
                        break;
                    }
                }

                if (quantidade > 1)
                {
                    break;
                }
            }

            naoPossuiCaracterReptido = quantidade == 1 ? true : false;

            return naoPossuiCaracterReptido;
        }
    }
}
