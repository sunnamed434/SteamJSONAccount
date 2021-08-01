using Gameloop.Vdf;
using Gameloop.Vdf.JsonConverter;
using Gameloop.Vdf.Linq;
using Newtonsoft.Json.Linq;
using SteamJSONAccount.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SteamJSONAccount
{
    public class Program
    {
        public const string SteamAccountsPath = @"D:\Games\Steam\config\loginusers.vdf";



        private static void Main(string[] args)
        {
            foreach (SteamAccount item in SteamAccountsUtility.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }

    public class SteamAccountsUtility
    {
        public static readonly string AccountName = nameof(AccountName);

        public static readonly string PersonaName = nameof(PersonaName);

        public static readonly string MostRecent = nameof(MostRecent);



        public const byte MostRecentValue = 1;



        public static IReadOnlyCollection<SteamAccount> GetAllAccounts()
        {
            List<SteamAccount> steamAccounts = new List<SteamAccount>();

            VProperty deserializedProperty = VdfConvert.Deserialize(File.ReadAllText(Program.SteamAccountsPath));

            foreach (JProperty property in deserializedProperty.ToJson().Value)
            {
                steamAccounts.Add(new SteamAccount(
                ulong.Parse(property.Name),
                property.Value[AccountName].ToString(),
                property.Value[PersonaName].ToString(),
                int.Parse(property.Value[MostRecent].ToString()) == MostRecentValue ? true : false));
            }

            return steamAccounts;
        }

        public static bool TryGetMostRecentAccount(out SteamAccount account) => (account = GetAllAccounts().FirstOrDefault(s => s.MostRecent == true)) != null;
    }
}
