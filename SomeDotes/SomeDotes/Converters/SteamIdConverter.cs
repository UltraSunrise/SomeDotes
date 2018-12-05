namespace SomeDotes.Converters
{
    public static class SteamIdConverter
    {
        public static long ConvertSteamIdToAccountId(long steamId)
        {
            return steamId - 76561197960265728;
        }
    }
}
