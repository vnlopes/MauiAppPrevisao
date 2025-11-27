using System;
using System.Threading.Tasks;

namespace MauiAppPrevisao.Services
{
    public class WeatherService
    {
        // Instância única (Singleton)
        private static WeatherService? _instance;
        public static WeatherService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WeatherService();
                return _instance;
            }
        }

        // Método Assíncrono para buscar previsão (Simulado)
        public async Task<string> GetPrevisaoAsync(string cidade)
        {
            // Simula um delay de rede (1 segundo) para parecer real
            await Task.Delay(1000);

            // Geração de dados aleatórios (Mock)
            Random rnd = new Random();
            int temp = rnd.Next(15, 35); // Temperatura entre 15 e 35

            string[] condicoes = { "Ensolarado", "Nublado", "Chuvoso", "Parcialmente Nublado", "Tempestade" };
            string condicao = condicoes[rnd.Next(condicoes.Length)];

            // Retorna no mesmo formato que a API retornaria
            return $"{temp}°C - {condicao}";
        }
    }
}