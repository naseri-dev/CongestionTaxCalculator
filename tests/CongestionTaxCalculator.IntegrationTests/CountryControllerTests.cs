using Application.Countries.Commands;
using Domain.Entities.Countries.Dtos;
using System.Net;

namespace CongestionTaxCalculator.IntegrationTests
{
    public class CountryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        private readonly Guid _countryId = Guid.Parse("b158fde2-fd7f-4e3f-98eb-2b248465aec9");

        public CountryControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task Get_country_by_id_returns_expected_country()
        {
            string url = $"/api/country/{_countryId}";

            var countryDto = await _httpClient.GetFromJsonAsync<CountryDto>(url);

            Assert.NotNull(countryDto);
            Assert.Equal("Germany", countryDto.Name);
        }
        [Fact]
        public async Task Create_adds_country_to_database()
        {
            string url = "/api/country";
            var createCommand = new CreateCountryCommand("Ukraine");
            var response = await _httpClient.PostAsJsonAsync(url, createCommand);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Update_should_changes_country_name()
        {
            string url = "/api/country";
            var createCommand = new EditCountryCommand(_countryId, "Scotland");
            var response = await _httpClient.PostAsJsonAsync(url, createCommand);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
