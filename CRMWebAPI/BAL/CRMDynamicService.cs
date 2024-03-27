using CRMWebAPI.Model;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CRMWebAPI.BAL
{
    public class CRMDynamicService
    {
        private readonly IConfidentialClientApplication _app;
        private readonly string _resourceUrl;
        private readonly string _apiVersion;

        public CRMDynamicService(string authority, string clientId, string clientSecret, string resourceUrl, string apiVersion)
        {
            _app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri(authority))
                .Build();
            _resourceUrl = resourceUrl;
            _apiVersion = apiVersion;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var result = await _app.AcquireTokenForClient(new[] { $"{_resourceUrl}/.default" }).ExecuteAsync();
            return result.AccessToken;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var accessToken = await GetAccessTokenAsync();
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{_resourceUrl}{_apiVersion}/accounts?$select=name,accountid&$top=10");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var accountResponse = JsonConvert.DeserializeObject<AccountResponse>(jsonResponse);
                return accountResponse?.Accounts ?? new List<Account>();
            }
            throw new HttpRequestException($"Failed to retrieve accounts. Status: {response.StatusCode}");
        }

        public async Task<List<Lead>> GetLeadsAsync()
        {
            var accessToken = await GetAccessTokenAsync();
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{_resourceUrl}{_apiVersion}/leads?$select=emailaddress1,address1_composite,companyname,jobtitle, subject&$top=100");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var accountResponse = JsonConvert.DeserializeObject<LeadResponce>(jsonResponse);
                return accountResponse?.Leads ?? new List<Lead>();
            }
            throw new HttpRequestException($"Failed to retrieve accounts. Status: {response.StatusCode}");
        }


        public async Task<List<Lead>> GetDealInformationByDealNumber(int versionnumber)
        {

            var accessToken = await GetAccessTokenAsync();
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{_resourceUrl}{_apiVersion}/leads?$filter=versionnumber eq {versionnumber}&$select=emailaddress1,address1_composite,companyname,jobtitle&$top=10");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var accountResponse = JsonConvert.DeserializeObject<LeadResponce>(jsonResponse);
                return accountResponse?.Leads ?? new List<Lead>();
            }
            throw new HttpRequestException($"Failed to retrieve accounts. Status: {response.StatusCode}");
        }

        public async Task<bool> InsertLeadAsync(Lead newLead)
        {
            var accessToken = await GetAccessTokenAsync();
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonContent = JsonConvert.SerializeObject(newLead);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{_resourceUrl}{_apiVersion}/leads", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException($"Failed to insert new lead. Status: {response.StatusCode}. Response: {await response.Content.ReadAsStringAsync()}");
            }
        }
    }
}
