using ValidaSenha.Model;
using ValidaSenha.Util;
using Xunit;

namespace ValidaSenhaUnitTest
{
    public class ValidaSenhaUnitTest
    {
        /*
        Nove ou mais caracteres
        Ao menos 1 dígito
        Ao menos 1 letra minúscula
        Ao menos 1 letra maiúscula
        Ao menos 1 caractere especial
        Considere como especial os seguintes caracteres: !@#$%^&*()-+
        Não possuir caracteres repetidos dentro do conjunto
         */
        private UsuarioValidator Validator { get; }
        public ValidaSenhaUnitTest()
        {
            Validator = new UsuarioValidator();
        }

        [Fact]
        public void SenhaInvalidaVazia()
        {
            Usuario usuario = new Usuario();
            usuario.Senha = string.Empty;

            var resultado = Validator.Validate(usuario).IsValid;

            Assert.False(resultado);
        }

        [Theory]
        [InlineData("!Ab1xcvbn")]
        [InlineData("A@b1xcvbn")]
        [InlineData("Ab#1xcvbn")]
        [InlineData("Ab1$xcvbn")]
        [InlineData("Ab1x%cvbn")]
        [InlineData("Ab1xc^vbn")]
        [InlineData("Ab1xcv&bn")]
        [InlineData("Ab1xcvb*n")]
        [InlineData("(Ab1xcvbn")]
        [InlineData("A)b1xcvbn")]
        [InlineData("Ab+1xcvbn")]
        [InlineData("Ab1-xcvbn")]
        [InlineData("!Ab1xcvbnT")]
        [InlineData("A@b1xcvbnT")]
        [InlineData("Ab#1xcvbnT")]
        [InlineData("Ab1$xcvbnT")]
        [InlineData("Ab1x%cvbnT")]
        [InlineData("Ab1xc^vbnT")]
        [InlineData("Ab1xcv&bnT")]
        [InlineData("Ab1xcvb*nT")]
        [InlineData("(Ab1xcvbnT")]
        [InlineData("A)b1xcvbnT")]
        [InlineData("Ab+1xcvbnT")]
        [InlineData("Ab1-xcvbnT")]
        public void SenhaValidaCaracteresEspeciaisETamanhoMin9(string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Senha = senha;

            var resultado = Validator.Validate(usuario).IsValid;

            Assert.True(resultado);
        }

        [Fact]
        public void SenhaInvalidaMenos9Caracteres()
        {
            Usuario usuario = new Usuario();
            usuario.Senha = "Ab1!xcvb";

            var resultado = Validator.Validate(usuario).IsValid;

            Assert.False(resultado);
        }

        [Theory]
        [InlineData("!AA1xcvbn")]
        [InlineData("A@bBxcvbn")]
        [InlineData("Ab#1xcCbn")]
        [InlineData("Ab1$xcvNn")]
        [InlineData("Ab1x%%vbn")]
        [InlineData("Ab1xc^^bn")]
     
        public void SenhaInvalidaCom9CaracteresRepeticao(string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Senha = senha;

            var resultado = Validator.Validate(usuario).IsValid;

            Assert.False(resultado);
        }
    }
}
