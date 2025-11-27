using MauiAppPrevisao.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MauiAppPrevisao.Services
{
    public class DatabaseService
    {
        private SQLiteConnection _connection;

        
        private static DatabaseService? _instance;
        public static DatabaseService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseService();
                return _instance;
            }
        }

        private DatabaseService()
        {
            
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app_previsao.db3");
            _connection = new SQLiteConnection(dbPath);

            
            _connection.CreateTable<Usuario>();
            _connection.CreateTable<HistoricoConsulta>();
        }

        
        public void CadastrarUsuario(Usuario usuario)
        {
            _connection.Insert(usuario);
        }

        public Usuario? Login(string email, string senha)
        {
            return _connection.Table<Usuario>()
                              .FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        
        public void RegistrarConsulta(HistoricoConsulta consulta)
        {
            _connection.Insert(consulta);
        }


        public List<HistoricoConsulta> FiltrarHistorico(int usuarioId, DateTime inicio, DateTime fim)
        {
            var todosDados = _connection.Table<HistoricoConsulta>().ToList();

            DateTime fimAjustado = new DateTime(fim.Year, fim.Month, fim.Day, 23, 59, 59);

 
            return todosDados
                    .Where(h => h.UsuarioId == usuarioId && h.DataConsulta >= inicio && h.DataConsulta <= fimAjustado)
                    .ToList();
        }
    }
}