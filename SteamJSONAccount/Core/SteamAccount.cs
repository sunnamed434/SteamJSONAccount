namespace SteamJSONAccount.Core
{
    public class SteamAccount : ISteamAccount
    {
        public ulong Id { get; }

        public string Name { get; }

        public string Nickname { get; }

        public bool MostRecent { get; }



        public SteamAccount(ulong id, string name, string nickName, bool mostRecent)
        {
            Id = id;
            Name = name;
            Nickname = nickName;
            MostRecent = mostRecent;
        }



        public override string ToString() => $"SteamId: {Id}, Name: {Name}, Nickname: {Nickname}, Is most recent: {(MostRecent == true ? "Yes" : "No")}";

        public bool Equals(SteamAccount target) => Id == target.Id;
    }
}
