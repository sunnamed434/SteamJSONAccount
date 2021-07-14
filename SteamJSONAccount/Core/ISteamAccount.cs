namespace SteamJSONAccount.Core
{
    public interface ISteamAccount
    {
        ulong Id { get; }

        string Name { get; }

        string Nickname { get; }

        bool MostRecent { get; }
    }
}
