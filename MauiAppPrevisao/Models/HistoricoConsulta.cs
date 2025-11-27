using SQLite;
using System;

namespace MauiAppPrevisao.Models
{
    public class HistoricoConsulta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // NOVO: Vincula a consulta ao usuário que fez
        public int UsuarioId { get; set; }

        public string Cidade { get; set; }
        public DateTime DataConsulta { get; set; }
        public string ResultadoPrevisao { get; set; }
    }
}