using System.ComponentModel.DataAnnotations;

namespace Imdb.Domain.AuthAggregate.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Este campo e obrigatorio")]
        [MaxLength(50, ErrorMessage = "Username deve conter no maximo 50 caracteres")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo e obrigatorio")]
        [MaxLength(10, ErrorMessage = "Senha deve conter no maximo 10 caracteres")]
        [MinLength(6, ErrorMessage = "Senha deve conter no minimo 6 caracteres")]
        public string Password { get; set; }
    }
}
