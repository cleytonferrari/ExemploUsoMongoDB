using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Usuario : Entidade
    {
        [StringLength(30, MinimumLength = 4, ErrorMessage = "O Login deve possuir de 4 a 30 caracteres")]
        [Required(ErrorMessage = "Preencha o campo login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Preencha o campo senha")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Preencha o campo nome")]
        public string Nome { get; set; }
    }
}
