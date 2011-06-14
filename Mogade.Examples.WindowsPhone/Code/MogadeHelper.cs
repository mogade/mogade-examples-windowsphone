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
//      private const string _gameKey = "4d6a4bf6bc7a05710a000011";
//      private const string _secret = "<_nnqvisX0T5L\\oTFLAcaCTY";
//      private static readonly IDictionary<Leaderboards, string> _leaderboardLookup = new Dictionary<Leaderboards, string>
//                                                                                     {
//                                                                                        {Leaderboards.Main, "4d6a4c32bc7a05710a000012"}
//                                                                                     };

      private const string _gameKey = "4d32a48b1d95175345000003";
      private const string _secret = "2AieOv9k:MZ]y@FGgo1WBQ6A;g\\>7Drp";
      private static readonly IDictionary<Leaderboards, string> _leaderboardLookup = new Dictionary<Leaderboards, string>
                                                                                           {
                                                                                              {Leaderboards.Main, "4d5f933e563d8a2e9900001b"}
                                                                                           };

      public static string LeaderboardId(Leaderboards leaderboard)
      {
         return _leaderboardLookup[leaderboard];
      }

      public static IMogadeClient CreateInstance()
      {
         //In your own game, when you are ready, REMOVE the ContectToTest to hit the production mogade server (instead of testing.mogade.com)
         //Also, if you are upgrading from the v1 library and you were using UserId (or not doing anything), you *must* change the UniqueIdStrategy to LegacyUserId
         MogadeConfiguration.Configuration(c => c.UsingUniqueIdStrategy(UniqueIdStrategy.UserId).ConnectTo("http://192.168.1.102:3000/api/"));
         return MogadeClient.Initialize(_gameKey, _secret);
      }
   }
}