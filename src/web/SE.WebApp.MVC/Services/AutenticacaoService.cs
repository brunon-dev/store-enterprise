using SE.WebApp.MVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(
                content: JsonSerializer.Serialize(usuarioLogin),
                encoding: Encoding.UTF8,
                mediaType: "application/json");

            var response = await _httpClient.PostAsync(requestUri: "https://localhost:44348/api/identidade/autenticar", loginContent);

            var teste = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(
                content: JsonSerializer.Serialize(usuarioRegistro),
                encoding: Encoding.UTF8,
                mediaType: "application/json");

            var response = await _httpClient.PostAsync(requestUri: "https://localhost:44348/api/identidade/nova-conta", registroContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
