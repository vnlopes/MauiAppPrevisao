using System;
using System.Threading.Tasks;

namespace MauiAppPrevisao.Services
{
    public class WeatherService
    {

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

        public async Task<string> GetPrevisaoAsync(string cidade)
        {
            await Task.Delay(1000);


            Random rnd = new Random();
            int temp = rnd.Next(15, 35); 

            string[] condicoes = { "Ensolarado", "Nublado", "Chuvoso", "Parcialmente Nublado", "Tempestade" };
            string condicao = condicoes[rnd.Next(condicoes.Length)];

            return $"{temp}°C - {condicao}";
        }
    }
}