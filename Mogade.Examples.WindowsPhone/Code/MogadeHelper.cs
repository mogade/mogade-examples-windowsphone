using System.Collections.Generic;
using Mogade.WindowsPhone;

namespace Mogade.Examples.WindowsPhone
{
   public enum Leaderboards
   {
      Main = 1,
   }
   public class MogadeHelper
   {
      //Your game key and game secret
      private const string _gameKey = "4e0888448fcd52202500000a";
      private const string _secret = "B:lkvrDb>AVmaR:Jwh:JqSdRDHy>K@1:Vrh";
      private static readonly IDictionary<Leaderboards, string> _leaderboardLookup = new Dictionary<Leaderboards, string>
                                                                                           {
                                                                                              {Leaderboards.Main, "4e08885d8fcd52202500000b"}
                                                                                           };

      public static string LeaderboardId(Leaderboards leaderboard)
      {
         return _leaderboardLookup[leaderboard];
      }

      public static IMogadeClient CreateInstance()
      {
         //In your own game, when you are ready, REMOVE the ContectToTest to hit the production mogade server (instead of testing.mogade.com)
         //Also, if you are upgrading from the v1 library and you were using UserId (or not doing anything), you *must* change the UniqueIdStrategy to LegacyUserId
         MogadeConfiguration.Configuration(c => c.UsingUniqueIdStrategy(UniqueIdStrategy.UserId));
         return MogadeClient.Initialize(_gameKey, _secret);
      }
   }
}