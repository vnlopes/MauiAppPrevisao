using SQLite;
using System;

namespace MauiAppPrevisao.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        // Validação solicitada na Model
        public bool Validar(out string mensagemErro)
        {
            mensagemErro = string.Empty;

            if (string.IsNullOrEmpty(Nome))
            {
                mensagemErro = "O Nome é obrigatório.";
                return false;
            }

            if (string.IsNullOrEmpty(Email) || !Email.Contains("@"))
            {
                mensagemErro = "E-mail inválido.";
                return false;
            }

            if (string.IsNullOrEmpty(Senha) || Senha.Length < 4)
            {
                mensagemErro = "A senha deve ter pelo menos 4 caracteres.";
                return false;
            }

            if (DataNascimento > DateTime.Now)
            {
                mensagemErro = "Data de nascimento inválida.";
                return false;
            }

            return true;
        }
    }
}