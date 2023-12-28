using System.Net.Http.Headers;
using System.Text;

namespace ClashOfClansAPI
{
    public class CocApiClient
    {
        public CocApiClient()
        {
            _httpClient = new HttpClient();
        }

        public CocApiClient(string uriString, string authorizationToken)
        {
            _uriString = uriString;
            _uri = new Uri(uriString);
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _uri;
            _authorizationToken = authorizationToken;
        }

        private string _authorizationToken;

        private Uri _uri;

        private HttpClient _httpClient;

        private string _uriString;


        #region Clan information methods

        public async Task<string> GetClanInfoAsync(string clanTag)
        {

            clanTag = Uri.EscapeDataString(clanTag);

            string finalUriString = _uriString + "clans/" + clanTag;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {
                    Console.WriteLine("Data recieved successfully!");
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        public async Task<string> GetCurrentClanWarInfoAsync(string clanTag)
        {

            clanTag = Uri.EscapeDataString(clanTag);

            string finalUriString = _uriString + "clans/" + clanTag + "/currentwar/leaguegroup";

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {

                    Console.WriteLine("Data recieved successfully!");
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        public async Task<string> GetClanWarLogInfoAsync(string clanTag)
        {

            clanTag = Uri.EscapeDataString(clanTag);

            string finalUriString = _uriString + "clans/" + clanTag + "/warlog";

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {

                    Console.WriteLine("Data recieved successfully!");
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        public async Task<string> GetClanWarLogInfoAsync(string clanTag, int itemsLimit)
        {

            clanTag = Uri.EscapeDataString(clanTag);

            string finalUriString = _uriString + "clans/" + clanTag + "/warlog?limit=" + itemsLimit;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {

                    Console.WriteLine("Data recieved successfully!");
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        public async Task<string> GetClansClanLeagueWarsInfoAsync(string clanTag)
        {

            clanTag = Uri.EscapeDataString(clanTag);

            string finalUriString = _uriString + "clanwarleagues/wars/" + clanTag;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {

                    Console.WriteLine("Data recieved successfully!");
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        public async Task<string> GetClanMembersAsync(string clanTag)
        {

            clanTag = Uri.EscapeDataString(clanTag);

            string finalUriString = _uriString + "clans/" + clanTag + "/members";

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {

                    Console.WriteLine("Data recieved successfully!");
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        public async Task<string> GetClanMembersAsync(string clanTag, int membersLimit)
        {

            clanTag = Uri.EscapeDataString(clanTag);

            string finalUriString = _uriString + "clans/" + clanTag + "/members?limit=" + membersLimit;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {

                    Console.WriteLine("Data recieved successfully!");
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        public async Task<string> GetClansClanCapitalRaidSeasonsInfoAsync(string clanTag)
        {

            clanTag = Uri.EscapeDataString(clanTag);

            string finalUriString = _uriString + "clans/" + clanTag + "/capitalraidseasons";

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {

                    Console.WriteLine("Data recieved successfully!");
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        #endregion


        #region Player information methods
        public async Task<string> GetPlayerInfoAsync(string playerTag)
        {
            playerTag = Uri.EscapeDataString(playerTag);

            string finalUriString = _uriString + "players/" + playerTag;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {
                    Console.WriteLine("Data recieved successfully!");

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
        public async Task<string> VerifyPlayerApiToken(string playerTag, string verifyToken)
        {
            playerTag = Uri.EscapeDataString(playerTag);

            string finalUriString = _uriString + "players/" + playerTag + "/verifytoken";

            string json = "{ \"token\": " + $"\"{verifyToken}\"" + " }";

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, finalUriString))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationToken);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine("Sending recieve data request...");

                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {
                    Console.WriteLine("Data recieved successfully!");

                    return await response.Content.ReadAsStringAsync();
                }
            }



        }

        #endregion


    }
}
