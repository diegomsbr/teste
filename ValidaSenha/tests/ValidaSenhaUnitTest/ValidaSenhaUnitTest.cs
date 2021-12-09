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
        [InlineData("!Ab1xcvPn")]
        [InlineData("A@b1xcvPn")]
        [InlineData("Ab#1xcvPn")]
        [InlineData("Ab1$xcvPn")]
        [InlineData("Ab1x%cvPn")]
        [InlineData("Ab1xc^vPn")]
        [InlineData("Ab1xcv&Pn")]
        [InlineData("Ab1xcvP*n")]
        [InlineData("(Ab1xcvPn")]
        [InlineData("A)b1xcvPn")]
        [InlineData("Ab+1xcvPn")]
        [InlineData("Ab1-xcvPn")]
        [InlineData("!Ab1xcvPnT")]
        [InlineData("A@b1xcvPnT")]
        [InlineData("Ab#1xcvPnT")]
        [InlineData("Ab1$xcvPnT")]
        [InlineData("Ab1x%cvPnT")]
        [InlineData("Ab1xc^vPnT")]
        [InlineData("Ab1xcv&PnT")]
        [InlineData("Ab1xcvP*nT")]
        [InlineData("(Ab1xcvPnT")]
        [InlineData("A)b1xcvPnT")]
        [InlineData("Ab+1xcvPnT")]
        [InlineData("Ab1-xcvPnT")]
        [InlineData("AbTp9!fok")]
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
        [InlineData("AAAbbbCcs")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]

        public void SenhaInvalidaComMin9CaracteresRepeticao(string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Senha = senha;

            var resultado = Validator.Validate(usuario).IsValid;

            Assert.False(resultado);
        }
    }
}
