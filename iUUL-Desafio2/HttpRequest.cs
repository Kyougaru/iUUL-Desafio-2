using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace iUUL_Desafio2
{
    public class HttpRequest
    {
        private static readonly HttpClient client = new();

        public static async Task<Exchangerate> Converter(string origem, string destino, string valor)
        {
            var endpoint = new Uri("https://api.exchangerate.host/convert?" + 
                "from=" + origem + 
                "&to=" + destino + 
                "&amount=" + valor);

            await using Stream stream = await client.GetStreamAsync(endpoint);
            Exchangerate exchangerate = await JsonSerializer.DeserializeAsync<Exchangerate>(stream);

            return exchangerate ?? new();
        }
    }
}
