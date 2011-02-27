using Mogade.WindowsPhone;

namespace Mogade.Examples.WindowsPhone
{
   public static class MogadeProvider
   {
      //Your game key and game secret
      private const string _gameKey = "4d6a4bf6bc7a05710a000011";
      private const string _secret = "<_nnqvisX0T5L\\oTFLAcaCTY";

      private static IMogadeClient _client;
      public static IMogadeClient GetInstance
      {
         get
         {
            if (_client == null)
            {
               _client = CreateClient();
            }
            return _client;
         }
      }

      private static IMogadeClient CreateClient()
      {
         //In your own game, when you are ready, REMOVE the ContectToTest to hit the production mogade server (instead of testing.mogade.com)
         MogadeConfiguration.Configuration(c => c.UsingUniqueIdStrategy(UniqueIdStrategy.UserId2).ConnectToTest());

         MogadeConfiguration.Configuration(c => c.UsingUniqueIdStrategy(UniqueIdStrategy.UserId2));
         _client = MogadeClient.Initialize(_gameKey, _secret);
         _client.LogApplicationStart();
         return _client;
      }
   }
}