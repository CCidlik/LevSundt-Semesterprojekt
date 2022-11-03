using LevSundt_Semesterprojekt.Infrastructure.Contact;
using LevSundt_Semesterprojekt.Infrastructure.Contact.Dto;
using System.Net.Http.Json;

namespace LevSundt_Semesterprojekt.Infrastructure.Implementation
{
    public class LevSundtService : ILevSundtService
    {
        private readonly HttpClient _httpClient;

        public LevSundtService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        async Task ILevSundtService.Create(BmiCreateRequestDto BmiCreateDto)
        {
            await _httpClient.PostAsJsonAsync($"api/Bmi", BmiCreateDto);
        }

        async Task ILevSundtService.Edit(BmiEditRequestDto BmiEditDto)
        {
           var response = await _httpClient.PostAsJsonAsync($"api/Bmi", BmiEditDto);
            if (response.IsSuccessStatusCode) return;

            var messege = await response.Content.ReadAsStringAsync();
            throw new Exception(messege);
        }

        async Task<BmiQueryResultDto> ILevSundtService.Get(int id, string UserId)
        {
            return await _httpClient.GetFromJsonAsync<BmiQueryResultDto>($"api/Bmi/{id}/{UserId}");
        }

        async Task<IEnumerable<BmiQueryResultDto>> ILevSundtService.GetAll(string UserId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BmiQueryResultDto>>($"api/Bmi/{UserId}");
        }
    }
}
