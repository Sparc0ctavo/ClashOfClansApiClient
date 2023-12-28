using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace ClashOfClansAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            CocApiClient client = BuildClient();

            switch (DisplayMenu())
            {
                case 49: Console.WriteLine("hdhcdhfdsuf"); break;
                case 50: await GetCocApiInfo(client); break;

                default: Console.WriteLine("HUI TU BYAT"); break;
            }


        }

        static async Task WriteJsonFileAsync(string jsonText)
        {

            Console.Write("Write JSON file name: ");
            string fileName = Console.ReadLine();

            string writePath = $"C:\\Users\\malya\\Desktop\\{fileName}.json";

            Console.WriteLine("Writing data in file...");

            using (FileStream stream = new FileStream(writePath, FileMode.CreateNew, FileAccess.Write))
            {

                byte[] buffer = Encoding.UTF8.GetBytes(jsonText);

                stream.Write(buffer, 0, buffer.Length);

            }

            Console.WriteLine("Successfully writen!\n");

            DisplayMenu();

        }

        private static CocApiClient BuildClient()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();


            string apiUri = configuration["ApiUri"];
            string authorizationToken = configuration["AuthorizationToken"];

            CocApiClient apiClient = new CocApiClient(apiUri, authorizationToken);

            return apiClient;
        }

        private static int DisplayMenu()
        {

            while (true)
            {

                Console.WriteLine("\n--------------------------MENU--------------------------\n");

                Console.WriteLine("CHOOSE ACTION(enter action number):");
                Console.WriteLine("1 - Rebuild client\n2 - Get COC API information");

                Console.Write("\nAction: ");
                return (int)Console.ReadKey().Key;

            }
        }

        private static async Task GetCocApiInfo(CocApiClient apiClient)
        {
            Console.WriteLine("\n--------------------MENU/GET API DATA-------------------\n");
            Console.WriteLine("1 - Clan informaiton\n2 - Player information");

            Console.Write("\nAction: ");
            int action = (int)Console.ReadKey().Key;

            if (action == 49)
            {
                Console.WriteLine("\n------------MENU/GET API DATA/CLAN INFORMATION----------\n");
                Console.WriteLine("1 - Get clan info\n2 - Get clan members\n3 Get clan warlog\n4 - Get clan's current war info");
                Console.WriteLine("5 - Get clan's clan league wars information\n6 - Get clan's capital raid info");

                Console.Write("\nAction: ");
                string defaultClanTag = "#CR8RP92C";
                int methodNumber = (int)Console.ReadKey().Key;
                Console.WriteLine("\n");

                if (methodNumber == 49)
                {
                    Console.Write("Enter clan tag(Skip to use default): ");
                    var clanTag = Console.ReadLine();
                    if (string.IsNullOrEmpty(clanTag)) clanTag = defaultClanTag;

                    await WriteJsonFileAsync(await apiClient.GetClanInfoAsync(clanTag));
                }
                else if (methodNumber == 50)
                {
                    Console.Write("Enter clan tag(Skip to use default): ");
                    string clanTag = Console.ReadLine();
                    if (string.IsNullOrEmpty(clanTag)) clanTag = defaultClanTag;

                    Console.Write("Enter members limit(how many matching members)(Skip to no limit): ");

                    string limitStr = Console.ReadLine();

                    if (string.IsNullOrEmpty(limitStr)) await WriteJsonFileAsync(await apiClient.GetClanMembersAsync(clanTag));
                    else
                    {
                        int limit = int.Parse(limitStr);
                        if(limit > 0) await WriteJsonFileAsync(await apiClient.GetClanMembersAsync(clanTag, limit));
                    }

                    
                     
                }
                else if (methodNumber == 51)
                {
                    Console.Write("Enter clan tag(Skip to use default): ");
                    string clanTag = Console.ReadLine();
                    if (string.IsNullOrEmpty(clanTag)) clanTag = defaultClanTag;

                    Console.Write("Enter log limit(how many matching logs)(Skip to no limit): ");
                    int limit = int.Parse(Console.ReadLine());

                    if (limit > 0) await WriteJsonFileAsync(await apiClient.GetClanWarLogInfoAsync(clanTag, limit));
                    else await WriteJsonFileAsync(await apiClient.GetClanWarLogInfoAsync(clanTag));
                }
                else if (methodNumber == 52)
                {
                    Console.Write("Enter clan tag(Skip to use default): ");
                    string clanTag = Console.ReadLine();
                    if (string.IsNullOrEmpty(clanTag)) clanTag = defaultClanTag;

                    await WriteJsonFileAsync(await apiClient.GetCurrentClanWarInfoAsync(clanTag));
                }
                else if (methodNumber == 53)
                {
                    Console.Write("Enter clan tag(Skip to use default): ");
                    string clanTag = Console.ReadLine();
                    if (string.IsNullOrEmpty(clanTag)) clanTag = defaultClanTag;

                    await WriteJsonFileAsync(await apiClient.GetClansClanLeagueWarsInfoAsync(clanTag));
                }
                else if (methodNumber == 54)
                {
                    Console.Write("Enter clan tag(Skip to use default): ");
                    string clanTag = Console.ReadLine();
                    if (string.IsNullOrEmpty(clanTag)) clanTag = defaultClanTag;

                    await WriteJsonFileAsync(await apiClient.GetClansClanCapitalRaidSeasonsInfoAsync(clanTag));
                }
            }

            DisplayMenu();
        }

    }
}