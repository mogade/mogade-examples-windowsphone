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
      private const string _gameKey = "4d6a4bf6bc7a05710a000011";
      private const string _secret = "<_nnqvisX0T5L\\oTFLAcaCTY";
      private static readonly IDictionary<Leaderboards, string> _leaderboardLookup = new Dictionary<Leaderboards, string>
                                                                                     {
                                                                                        {Leaderboards.Main, "4d6a4c32bc7a05710a000012"}
                                                                                     };

      public static string LeaderboardId(Leaderboards leaderboard)
      {
         return _leaderboardLookup[leaderboard];
      }

      public static IMogadeClient CreateInstance()
      {
         //In your own game, when you are ready, REMOVE the ContectToTest to hit the production mogade server (instead of testing.mogade.com)
         MogadeConfiguration.Configuration(c => c.UsingUniqueIdStrategy(UniqueIdStrategy.UserId2).ConnectToTest());
         return MogadeClient.Initialize(_gameKey, _secret);
      }
   }
}