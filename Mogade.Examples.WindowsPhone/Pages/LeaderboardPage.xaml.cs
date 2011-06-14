using System;
using System.Windows;

namespace Mogade.Examples.WindowsPhone.Pages
{
   public partial class LeaderboardPage
   {
      private static readonly LeaderboardScope[] _scopeOrder = new[]{LeaderboardScope.Overall, LeaderboardScope.Weekly, LeaderboardScope.Daily};
      private LeaderboardScope _scope;
      private int _page;

      public LeaderboardPage()
      {
         InitializeComponent();
      }

      protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
      {
         _scope = _scopeOrder[0];
         _page = 1;
         LoadLeaderboard();
         base.OnNavigatedTo(e);
      }

      private void NextScope_Click(object sender, RoutedEventArgs e)
      {
         var index = Array.IndexOf(_scopeOrder, _scope);
         if (++index == _scopeOrder.Length)
         {
            index = 0;
         }
         _scope = _scopeOrder[index];
         LoadLeaderboard();
      }

      private void PreviousScope_Click(object sender, RoutedEventArgs e)
      {
         var index = Array.IndexOf(_scopeOrder, _scope);
         if (--index == -1)
         {
            index = _scopeOrder.Length - 1;
         }
         _scope = _scopeOrder[index];
         LoadLeaderboard();
      }

      private void LoadLeaderboard()
      {
         ScopeTitle.Text = _scope.ToString();
         //we can avoid the cross-thread issue by dispatching the entire callback, but don't do too much!
         Mogade.GetLeaderboard(MogadeHelper.LeaderboardId(Leaderboards.Main), _scope, _page, r => Dispatcher.BeginInvoke(() => LeaderboardReceived(r)));
         //could put a loading message here
      }

      private void LeaderboardReceived(Response<LeaderboardScores> response)
      {
         //would hide the loading message here
         if (!response.Success)
         {
            //todo handle the error, maybe display a message to the user
         }
         else
         {
            Scores.Children.Clear();
            for (var i = 0; i < response.Data.Scores.Count; ++i)
            {
               var row = new ScoreRow(response.Data.Scores[i]);
               Scores.Children.Add(row);
            }
         }
      }

      private void Home_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
      }
   }
}