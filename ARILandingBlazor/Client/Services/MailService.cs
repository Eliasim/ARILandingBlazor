using ARILandingBlazor.Client.Model;
using ARILandingBlazor.Client.Interfaces;
using System.Net.Http.Json;

namespace ARILandingBlazor.Client.Services
{
    public class MailService : IMailService
    {
        private readonly HttpClient _httpClient;

        public MailService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

        public async Task<bool> Email(EmailBody email)
        {
            var result = await _httpClient.PostAsJsonAsync<EmailBody>("api/Mail", email);

            return result != null;
        }
    }
}
